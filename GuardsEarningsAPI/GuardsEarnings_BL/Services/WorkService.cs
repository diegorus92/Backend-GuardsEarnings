using GuardsEarnings_BL.Dtos;
using GuardsEarnings_DAL.Models;
using GuardsEarnings_DAL.Repositories;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardsEarnings_BL.Services
{
    public class WorkService : IWorkService
    {
        private readonly IWorkRepository _repository;

        public WorkService(
                IWorkRepository repository
            )
        {
            _repository = repository;
        }




        public bool CreateWork(WorkDTO work)
        {
            Work newWork = new Work();
            newWork.Guard = new Guard();
            newWork.Target = new Target();
            newWork.Journey = new Journey();

            newWork.WorkId = 0;
            newWork.EnterTime = work.EnterTime;
            newWork.OutTime = work.OutTime;
            newWork.Payment = work.Payment;

            Guard guard = new Guard();
            Target target = new Target();
            Journey journey = new Journey();

            guard.GuardId = work.NewGuardId;
            target.TargetId = work.NewTargetId;
            journey.JourneyId = work.NewJourneyId;

            newWork.Guard = guard;
            newWork.Target = target;
            newWork.Journey = journey;

            

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

        public ICollection<Work> GetWorksByGuardAndDate(long guardId, int year, int month)
        {
            return _repository.SearchWorksByGuardAndDate(guardId, year, month);    
        }

        public bool UpdateWork(long id, WorkDTO work)
        {
            Work? workToUpdate = _repository.Get(id) ;
            if (workToUpdate == null) return false;
            workToUpdate.WorkId = id;
            workToUpdate.EnterTime = work.EnterTime;
            workToUpdate.OutTime = work.OutTime;
            workToUpdate.Payment = work.Payment;

           
            _repository.UpdateCompleteWork(workToUpdate, work.NewGuardId, work.NewTargetId, work.NewJourneyId);
            return true;
        }

    }
}
