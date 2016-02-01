using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFCrimeDatabaseService.Contexts;
using SFCrimeDatabaseService.Repositories;
using SFCrimeDatabaseService.Services;

namespace SFCrimeDatabaseService
{
    public class Instantiator
    {

        public ITestCrimeService GettNewTestCrimeService(string connectionString, IContext ctx)
        {
            return new TestCrimeService(GetTestCrimeRepository(connectionString, ctx));
        }

        public ITestCrimeRepository GetTestCrimeRepository(string connectionString, IContext ctx)
        {
            if (ctx != null)
                return new TestCrimeRepository(ctx);
            return new TestCrimeRepository(GetContext(connectionString));
        }

        public ITrainingCrimeService GetTrainingCrimeService(string connectionString, IContext ctx)
        {
            return new TrainingCrimeService(GetTrainingCrimeRepository(connectionString, ctx));
        }

        public ITrainingCrimeRepository GetTrainingCrimeRepository(string connectionString, IContext ctx)
        {
            if (ctx != null)
                return new TrainingCrimeRepository(ctx);
            return new TrainingCrimeRepository(GetContext(connectionString));
        }

        public IContext GetContext(string connectionString)
        {
            return new SFContext(connectionString);
        }
    }
}
