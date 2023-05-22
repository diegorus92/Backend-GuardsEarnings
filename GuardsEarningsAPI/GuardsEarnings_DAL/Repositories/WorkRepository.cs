using GuardsEarnings_DAL.Data;
using GuardsEarnings_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
//using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardsEarnings_DAL.Repositories
{
    public class WorkRepository : IWorkRepository//IRepository<Work>
    {
        private readonly Context _context;

        public WorkRepository(Context context)
        {
                _context = context;
        }




        public void Create(Work entity)
        {
            Work work = new Work();

            work.WorkId = entity.WorkId;
            work.EnterTime = entity.EnterTime;
            work.OutTime = entity.OutTime;
            work.Payment = entity.Payment;
            work.Guard = new Guard();
            work.Target = new Target();
            work.Journey = new Journey();

            //var relatedGuard = _context.Guards.FirstOrDefault(g => g.GuardId == 1);
            var relatedGuard = _context.Guards.Find(entity.Guard.GuardId);
            var relatedTarget = _context.Targets.Find(entity.Target.TargetId);
            var relatedJourney = _context.Journeys.Find(entity.Journey.JourneyId);

            if(relatedGuard != null && relatedTarget != null && relatedJourney != null) 
            {
                work.Guard = relatedGuard;
                work.Target = relatedTarget;
                work.Journey = relatedJourney;

                _context.Works.Add(work);
                Save();
            }

        }

        public void Delete(Work entity)
        {
            _context.Works.Remove(entity);
            Save();
        }

        public Work? Get(long id)
        {
            Work? work = _context.Works.Find(id);

            
            if (work == null)
            {
                return null;
            }

            _context.Entry(work).Reference(w => w.Guard).Load();
            _context.Entry(work).Reference(w => w.Target).Load();
            _context.Entry(work).Reference(w => w.Journey).Load();
            return work;
        }

        public ICollection<Work> GetAll()
        {
            ICollection<Work> works = _context.Works.ToList();
            return works;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public ICollection<Work> SearchWorksByGuardAndDate(long guardId, int year, int month)
        {
            ICollection<Work> works = _context.Works.
                Where(work => work.Guard.GuardId == guardId && work.Journey.Date.Year == year && work.Journey.Date.Month == month).AsQueryable().ToList() ;
            

            foreach(Work w in works)
            {
                _context.Entry(w).Reference(w => w.Journey).Load();
                _context.Entry(w).Reference(w => w.Target).Load();
            }

            return works;
        }

        public void Update(Work entity)
        {
            _context.Works.Update(entity);
            Save();
        }

        public void UpdateCompleteWork(Work entity, long guardId, long targetId, long journeyId)
        {
            Guard? guard = _context.Guards.Find(guardId);
            Target? target = _context.Targets.Find(targetId);
            Journey? journey = _context.Journeys.Find(journeyId);

            if(guard != null && journey != null && target != null) 
            {
                entity.Guard = guard;
                entity.Target = target;
                entity.Journey = journey;
            }

            _context.Works.Update(entity);
            Save();
        }

    }
}
