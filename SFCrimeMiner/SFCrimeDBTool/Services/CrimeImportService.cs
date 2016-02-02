using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToExcel;
using SFCrimeDatabaseService.Entities;
using SFCrimeDBTool.Utilities;

namespace SFCrimeDBTool.Services
{
    public class CrimeImportService : ICrimeImportService
    {
        public List<string> GetAllFileNames(string path)
        {
            return Directory.GetFiles(path, "*.*")
                .Select(Path.GetFileName)
                .ToList();
        }

        public List<T> GetCrimesFromFile<T>(string filePath)
        {
            var excelDoc = new ExcelQueryFactory(filePath);

            if (typeof (T) == typeof (TestCrime))
            {
                return (List<T>) excelDoc.Worksheet()
                    .Select(x => new TestCrime
                    {
                        Address = x["Address"],
                        Date = DateTime.Parse(x["Dates"]),
                        DayOfWeek = x["DayOfWeek"],
                        OriginalId = x["Id"],
                        Latitude = Convert.ToDouble(x["X"]),
                        Longitude = Convert.ToDouble(x["Y"]),
                        PDDistrict = x["PdDistrict"]
                    });
            }
            else if (typeof (T) == typeof (TrainingCrime))
            {
                return (List<T>) excelDoc.Worksheet()
                    .Select(x => new TrainingCrime
                    {
                        Address = x["Address"],
                        Category = x["Category"],
                        Date = DateTime.Parse(x["Dates"]),
                        DayOfWeek = x["DayOfWeek"],
                        Description = x["Description"],
                        Latitude = Convert.ToDouble(x["X"]),
                        Longitude = Convert.ToDouble(x["Y"]),
                        PDDistrict = x["PdDistrict"],
                        Resolution = x["Resolution"]
                    });
            }
            throw new UnsupportedTypeException(typeof(T).FullName);
        }

        public void PopulateDatabase(ThreadBundle bundle)
        {
            foreach (var filePath in bundle.FilePaths)
            {
                switch (bundle.Option)
                {
                    case 0:
                        var testCrimes = GetCrimesFromFile<TestCrime>(filePath);
                        foreach (var testCrime in testCrimes)
                        {
                            bundle.TestCrimeService.AddTestCrime(testCrime);
                        }
                        break;
                    case 1:
                        var trainingCrimes = GetCrimesFromFile<TrainingCrime>(filePath);
                        foreach (var trainingCrime in trainingCrimes)
                        {
                            bundle.TrainingCrimeService.AddTrainingCrime(trainingCrime);
                        }
                        break;
                }
            }
        }
    }
}
