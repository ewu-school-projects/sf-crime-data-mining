using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFCrimeDatabaseService;
using SFCrimeDatabaseService.Services;
using SFCrimeDBTool.Services;
using SFCrimeDBTool.Utilities;

namespace SFCrimeDBTool
{
    public class Program
    {
        public string ConnectionString { get; set; }

        public static void Main(string[] args)
        {
            var p = new Program
            {
                ConnectionString = new AppSettingsReader().GetValue("sfCrimeDb", typeof (string)).ToString()
            };
            
            Console.WriteLine("Please enter password to connect to db: ");
            var password = Console.ReadLine();

            p.ConnectionString = p.ConnectionString.Replace("{{password}}", password);

            p.Run();
        }

        public void Run()
        {
            // Runs a thread in the background to monitor threads and join them to monitor thread
            var threadManager = (IThreadManager) new ThreadManager();

            var crimeImportService = (ICrimeImportService) new CrimeImportService();

            // Get list of files in directories
            var testFiles = crimeImportService.GetAllFileNames("..\\..\\test_data");
            var trainingFiles = crimeImportService.GetAllFileNames("..\\..\\training_data");

            for (var i = 0; i < 4; ++i)
            {
                // Setup a thread to load test crime data from csv to database
                var bundle1 = new ThreadBundle
                {
                    FilePaths = testFiles.Skip(i*(int)Math.Ceiling((double)(testFiles.Count/4)))
                                         .Take((int)Math.Ceiling((double)(testFiles.Count / 4)))
                                         .ToList(),
                    Option = 0,
                    TestCrimeService = new Instantiator().GetNewTestCrimeService(ConnectionString, null)
                };
                var thread1 = threadManager.CreateNewThread(bundle1, crimeImportService,
                    crimeImportService.GetType().GetMethod("PopulateDatabase"));

                // Setup a thread to load training crime data from csv to database
                var bundle2 = new ThreadBundle
                {
                    FilePaths = trainingFiles.Skip(i * (int)Math.Ceiling((double)(trainingFiles.Count / 4)))
                                         .Take((int)Math.Ceiling((double)(trainingFiles.Count / 4)))
                                         .ToList(),
                    Option = 1,
                    TrainingCrimeService = new Instantiator().GetTrainingCrimeService(ConnectionString, null)
                };
                var thread2 = threadManager.CreateNewThread(bundle2, crimeImportService,
                    crimeImportService.GetType().GetMethod("PopulateDatabase"));

                // Start threads and add to monitor
                thread1.Start();
                thread2.Start();
                threadManager.WatchThread(thread1);
                threadManager.WatchThread(thread2);
            }

            threadManager.JoinAll();
        }

        public void TestRun()
        {
            var threadManager = (IThreadManager) new ThreadManager();
            var threadBundle = new ThreadBundle();

            var thread = threadManager.CreateNewThread(threadBundle, this, this.GetType().GetMethod("Test"));

            thread.Start();
            thread.Join();
        }

        public void Test(ThreadBundle bundle)
        {
            Console.WriteLine("Successful method call");
        }
    }
}
