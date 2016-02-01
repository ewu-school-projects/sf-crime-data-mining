using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFCrimeDBTool.Utilities;

namespace SFCrimeDBTool
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var p = new Program();
            var threadManager = (IThreadManager) new ThreadManager();
            var threadBundle = new ThreadBundle();

            var thread = threadManager.CreateNewThread(threadBundle, p, p.GetType().GetMethod("Test"));

            thread.Start();
            thread.Join();
        }

        public void Test(ThreadBundle bundle)
        {
            Console.WriteLine("Successful method call");
        }
    }
}
