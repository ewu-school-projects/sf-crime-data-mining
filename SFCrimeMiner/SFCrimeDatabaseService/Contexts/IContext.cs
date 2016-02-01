using MongoDB.Driver;
using SFCrimeDatabaseService.Entities;

namespace SFCrimeDatabaseService.Contexts
{
    public interface IContext
    {
        IMongoCollection<TestCrime> TestCrimes();

        IMongoCollection<TrainingCrime> TrainingCrimes();
    }
}