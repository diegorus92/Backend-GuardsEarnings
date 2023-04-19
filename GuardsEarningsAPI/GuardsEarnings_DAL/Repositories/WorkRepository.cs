using GuardsEarnings_DAL.Data;
using GuardsEarnings_DAL.Models;
using System;
using System.Collections.Generic;
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
            work.QtyHours = entity.QtyHours;
            work.Guards = new List<Guard>();
            work.Targets = new List<Target>();
            work.Journeys = new List<Journey>();

            //var relatedGuard = _context.Guards.FirstOrDefault(g => g.GuardId == 1);
            var relatedGuard = _context.Guards.Find(entity.Guards.LastOrDefault().GuardId);
            var relatedTarget = _context.Targets.Find(entity.Targets.LastOrDefault().TargetId);
            var relatedJourney = _context.Journeys.Find(entity.Journeys.LastOrDefault().JourneyId);

            if(relatedGuard != null && relatedTarget != null && relatedJourney != null) 
            {
                work.Guards.Add(relatedGuard);
                work.Targets.Add(relatedTarget);
                work.Journeys.Add(relatedJourney);

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

            _context.Entry(work).Collection(w => w.Guards).Load();
            _context.Entry(work).Collection(w => w.Targets).Load();
            _context.Entry(work).Collection(w => w.Journeys).Load();
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
    }
}
