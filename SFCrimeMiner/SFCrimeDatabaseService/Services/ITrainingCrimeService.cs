using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SFCrimeDatabaseService.Entities;

namespace SFCrimeDatabaseService.Services
{
    public interface ITrainingCrimeService
    {
        void AddTrainingCrime(TrainingCrime crime);

        TrainingCrime GetTrainingCrimeByDateTime(DateTime dateTime);

        TrainingCrime GetTrainingCrime(Expression<Func<TrainingCrime, bool>> expression);

        IEnumerable<TrainingCrime> GetAllByCategory(string category);

        IEnumerable<TrainingCrime> GetAllByResolution(string resolution);

        IEnumerable<TrainingCrime> GetAllByPDDistrict(string pdDistrict);

        IEnumerable<TrainingCrime> GetAllFiltered(Expression<Func<TrainingCrime, bool>> expression);

        IEnumerable<TrainingCrime> GetAll();

        void Update(TrainingCrime crime);
    }
}
