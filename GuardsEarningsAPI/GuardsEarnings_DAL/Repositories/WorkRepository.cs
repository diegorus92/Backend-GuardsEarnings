using GuardsEarnings_DAL.Data;
using GuardsEarnings_DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardsEarnings_DAL.Repositories
{
    public class WorkRepository : IRepository<Work>
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

        public void Update(Work entity)
        {
            _context.Works.Update(entity);
            Save();
        }

        public Guard? GetWorkOfGuards(long guardId)
        {
            throw new NotImplementedException();    
        }

        
    }
}
