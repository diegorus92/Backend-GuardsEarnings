using GuardsEarnings_BL.Dtos;
using GuardsEarnings_DAL.Models;
using GuardsEarnings_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardsEarnings_BL.Services
{
    public class WorkService : IWorkService
    {
        private readonly IRepository<Work> _repository;

        public WorkService(
                IRepository<Work> repository
            )
        {
            _repository = repository;
        }




        public bool CreateWork(WorkDTO work)
        {
            Work newWork = new Work();
            newWork.Guards = new List<Guard>();
            newWork.Targets = new List<Target>();
            newWork.Journeys = new List<Journey>();

            newWork.WorkId = 0;
            newWork.QtyHours = work.QtyHours;

            Guard guard = new Guard();
            Target target = new Target();
            Journey journey = new Journey();

            guard.GuardId = work.NewGuardId;
            target.TargetId = work.NewTargetId;
            journey.JourneyId = work.NewJourneyId;

            newWork.Guards.Add(guard);
            newWork.Targets.Add(target);
            newWork.Journeys.Add(journey);

            

            _repository.Create( newWork );
            return true;
        }

        public bool DeleteWork(long id)
        {
            Work? work = _repository.Get(id);
            if (work == null) return false;
            _repository.Delete(work);
            return true;    
        }

        public Work? GetWork(long id)
        {
            return _repository.Get(id);
        }

        public ICollection<Work> GetWorks()
        {
            return _repository.GetAll();
        }

        public bool UpdateWork(long id, WorkDTO work)
        {
            Work? workToUpdate = _repository.Get(id) ;
            if (workToUpdate == null) return false;
            workToUpdate.WorkId = id;
            workToUpdate.QtyHours = work.QtyHours;

            _repository.Update(workToUpdate);
            return true;
        }
    }
}
