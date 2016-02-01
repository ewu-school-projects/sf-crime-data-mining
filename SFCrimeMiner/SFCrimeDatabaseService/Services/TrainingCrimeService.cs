using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SFCrimeDatabaseService.Entities;
using SFCrimeDatabaseService.Repositories;

namespace SFCrimeDatabaseService.Services
{
    public class TrainingCrimeService : ITrainingCrimeService
    {
        private readonly ITrainingCrimeRepository _tcRepo;

        public TrainingCrimeService(ITrainingCrimeRepository trainingCrimeRepository)
        {
            _tcRepo = trainingCrimeRepository;
        }

        public void AddTrainingCrime(TrainingCrime crime)
        {
            if (crime == null)
                throw new ArgumentNullException(nameof(crime));

            _tcRepo.Add(crime);
        }

        public TrainingCrime GetTrainingCrimeByDateTime(DateTime dateTime)
        {
            return GetTrainingCrime(x => x.Date == dateTime);
        }

        public TrainingCrime GetTrainingCrime(Expression<Func<TrainingCrime, bool>> expression)
        {
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            return _tcRepo.GetOne(expression);
        }

        public IEnumerable<TrainingCrime> GetAllByCategory(string category)
        {
            if (string.IsNullOrEmpty(category))
                throw new ArgumentNullException(nameof(category));

            return GetAllFiltered(x => x.Category == category);
        }

        public IEnumerable<TrainingCrime> GetAllByResolution(string resolution)
        {
            if (string.IsNullOrEmpty(resolution))
                throw new ArgumentNullException(nameof(resolution));

            return GetAllFiltered(x => x.Resolution == resolution);
        }

        public IEnumerable<TrainingCrime> GetAllByPDDistrict(string pdDistrict)
        {
            if (string.IsNullOrEmpty(pdDistrict))
                throw new ArgumentNullException(nameof(pdDistrict));

            return GetAllFiltered(x => x.PDDistrict == pdDistrict);
        }

        public IEnumerable<TrainingCrime> GetAllFiltered(Expression<Func<TrainingCrime, bool>> expression)
        {
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            return _tcRepo.GetAll(expression);
        }

        public IEnumerable<TrainingCrime> GetAll()
        {
            return _tcRepo.GetAll();
        }

        public void Update(TrainingCrime crime)
        {
            if (crime == null)
                throw new ArgumentNullException(nameof(crime));
            if (string.IsNullOrEmpty(crime.Id))
                throw new ArgumentNullException(nameof(crime.Id));
            if (GetTrainingCrime(x => x.Id == crime.Id) == null)
                throw new NotFoundException(crime.Id);

            _tcRepo.Update(crime);
        }
    }
}
