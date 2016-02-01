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
    public class TestCrimeRepository : ITestCrimeRepository
    {
        private readonly IContext _db;

        public TestCrimeRepository(IContext ctx)
        {
            _db = ctx;
        }

        public void Add(TestCrime crime)
        {
            _db.TestCrimes()
                .InsertOne(crime);
        }

        public TestCrime GetOne(Expression<Func<TestCrime, bool>> expression)
        {
            return _db.TestCrimes()
                .Find(expression)
                .ToList()
                .FirstOrDefault();
        }

        public IEnumerable<TestCrime> GetAll()
        {
            return _db.TestCrimes()
                .Find(x => true)
                .ToList();
        }

        public IEnumerable<TestCrime> GetAll(Expression<Func<TestCrime, bool>> expression)
        {
            return _db.TestCrimes()
                .Find(expression)
                .ToList();
        }

        public void Update(TestCrime crime)
        {
            _db.TestCrimes().FindOneAndReplace(x => x.Id == crime.Id, crime);
        }
    }
}
