using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SFCrimeDatabaseService.Entities;

namespace SFCrimeDatabaseService.Repositories
{
    public interface ITestCrimeRepository
    {
        void Add(TestCrime crime);

        TestCrime GetOne(Expression<Func<TestCrime, bool>> expression);

        IEnumerable<TestCrime> GetAll();

        IEnumerable<TestCrime> GetAll(Expression<Func<TestCrime, bool>> expression);

        void Update(TestCrime crime);
    }
}
