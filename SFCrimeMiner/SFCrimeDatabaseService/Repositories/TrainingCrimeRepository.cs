using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using SFCrimeDatabaseService.Contexts;
using SFCrimeDatabaseService.Entities;

namespace SFCrimeDatabaseService.Repositories
{
    public class TrainingCrimeRepository : ITrainingCrimeRepository
    {
        private readonly IContext _db;

        public TrainingCrimeRepository(IContext ctx)
        {
            _db = ctx;
        }

        public void Add(TrainingCrime crime)
        {
            _db.TrainingCrimes()
                .InsertOne(crime);
        }

        public TrainingCrime GetOne(Expression<Func<TrainingCrime, bool>> expression)
        {
            return _db.TrainingCrimes()
                .Find(expression)
                .ToList()
                .FirstOrDefault();
        }

        public IEnumerable<TrainingCrime> GetAll()
        {
            return _db.TrainingCrimes()
                .Find(x => true)
                .ToList();
        }

        public IEnumerable<TrainingCrime> GetAll(Expression<Func<TrainingCrime, bool>> expression)
        {
            return _db.TrainingCrimes()
                .Find(expression)
                .ToList();
        }

        public void Update(TrainingCrime crime)
        {
            _db.TrainingCrimes().FindOneAndReplace(x => x.Id == crime.Id, crime);
        }
    }
}
