using GuardsEarnings_DAL.Data;
using GuardsEarnings_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardsEarnings_DAL.Repositories
{
    public class JourneyRepository : IRepository<Journey>
    {
        private readonly Context _context;

        public JourneyRepository(Context context)
        {
            _context = context;
        }




        public void Create(Journey entity)
        {
            _context.Journeys.Add(entity);
            Save();
        }

        public void Delete(Journey entity)
        {
            _context.Journeys.Remove(entity);
            Save();
        }

        public Journey? Get(long id)
        {
            Journey? journey = _context.Journeys.Find(id);
            if (journey == null)
                return null;
            return journey;
        }

        public ICollection<Journey> GetAll()
        {
            ICollection<Journey> journeys = _context.Journeys.ToList();
            return journeys;
        }

        public Guard? GetWorkOfGuards(long guardId)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Journey entity)
        {
            _context.Journeys.Update(entity);
            Save();
        }

        public void UpdateCompleteWork(Work workToUpdate, long newGuardId, long newTargetId, long newJourneyId)
        {
            throw new NotImplementedException();
        }
    }
}
