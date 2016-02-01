using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SFCrimeDatabaseService.Entities;

namespace SFCrimeDatabaseService.Repositories
{
    public interface ITrainingCrimeRepository
    {
        void Add(TrainingCrime crime);

        TrainingCrime GetOne(Expression<Func<TrainingCrime, bool>> expression);

        IEnumerable<TrainingCrime> GetAll();

        IEnumerable<TrainingCrime> GetAll(Expression<Func<TrainingCrime, bool>> expression);

        void Update(TrainingCrime crime);
    }
}
