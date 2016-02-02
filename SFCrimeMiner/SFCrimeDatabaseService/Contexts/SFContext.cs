using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using SFCrimeDatabaseService.Entities;

namespace SFCrimeDatabaseService.Contexts
{
    public class SFContext : IContext
    {
        public IMongoDatabase _db;

        public SFContext(string connectionString)
        {
            _db = (new MongoClient(connectionString).GetDatabase(connectionString.Split('/').Last()));
        }

        public IMongoCollection<TestCrime> TestCrimes()
        {
            return _db.GetCollection<TestCrime>("TestCrime");
        }

        public IMongoCollection<TrainingCrime> TrainingCrimes()
        {
            return _db.GetCollection<TrainingCrime>("TrainingCrime");
        }
    }
}
