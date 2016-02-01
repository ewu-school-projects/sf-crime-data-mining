using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SFCrimeDatabaseService.Entities;

namespace SFCrimeDatabaseService.Services
{
    public interface ITestCrimeService
    {
        void AddTestCrime(TestCrime crime);

        TestCrime GetTestCrimeByOriginalId(string id);

        TestCrime GetTestCrimeByDateTime(DateTime dateTime);

        TestCrime GetTestCrime(Expression<Func<TestCrime, bool>> expression);

        IEnumerable<TestCrime> GetTestCrimesByDate(DateTime date);

        IEnumerable<TestCrime> GetTestCrimesFiltered(Expression<Func<TestCrime, bool>> expression);

        IEnumerable<TestCrime> GetTestCrimes();

        void Update(TestCrime crime);
    }
}
