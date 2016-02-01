using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFCrimeDatabaseService.Services;

namespace SFCrimeDBTool.Utilities
{
    public class ThreadBundle
    {
        public List<string> FilePaths { get; set; } 
        
        public ITrainingCrimeService TrainingCrimeService { get; set; }

        public ITestCrimeService TestCrimeService { get; set; }
    }
}
