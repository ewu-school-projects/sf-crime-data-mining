using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using SFCrimeDatabaseService.Entities;
using SFCrimeDatabaseService.Repositories;

namespace SFCrimeDatabaseService.Services
{
    public class TestCrimeService : ITestCrimeService
    {
        private readonly ITestCrimeRepository _tcRepo;

        public TestCrimeService(ITestCrimeRepository testCrimeRepository)
        {
            _tcRepo = testCrimeRepository;
        }

        public void AddTestCrime(TestCrime crime)
        {
            if (crime == null)
                throw new ArgumentNullException(nameof(crime));

            crime.Id = ObjectId.GenerateNewId().ToString();

            _tcRepo.Add(crime);
        }

        public TestCrime GetTestCrimeByOriginalId(string id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return GetTestCrime(x => x.OriginalId == id);
        }

        public TestCrime GetTestCrimeByDateTime(DateTime dateTime)
        {
            return GetTestCrime(x => x.Date == dateTime);
        }

        public TestCrime GetTestCrime(Expression<Func<TestCrime, bool>> expression)
        {
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            return _tcRepo.GetOne(expression);
        }

        public IEnumerable<TestCrime> GetTestCrimesByDate(DateTime date)
        {
            return GetTestCrimesFiltered(x => x.Date == date);
        }

        public IEnumerable<TestCrime> GetTestCrimesFiltered(Expression<Func<TestCrime, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TestCrime> GetTestCrimes()
        {
            return _tcRepo.GetAll();
        }

        public void Update(TestCrime crime)
        {
            if (crime == null)
                throw new ArgumentNullException(nameof(crime));
            if (string.IsNullOrEmpty(crime.Id))
                throw new ArgumentException(nameof(crime.Id));
            if (GetTestCrime(x => x.Id == crime.Id) == null)
                throw new NotFoundException(crime.Id);

            _tcRepo.Update(crime);
        }
    }
}
