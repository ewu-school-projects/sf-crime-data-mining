using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFCrimeDBTool.Utilities;

namespace SFCrimeDBTool.Services
{
    public interface ICrimeImportService
    {
        List<string> GetAllFileNames(string path);

        List<T> GetCrimesFromFile<T>(string filePath);

        void PopulateDatabase(ThreadBundle bundle);
    }
}
