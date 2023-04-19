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
    public class JourneyService : IJourneyService
    {
        private readonly IRepository<Journey> _journeyRepository;

        public JourneyService(IRepository<Journey> journeyRepository)
        {
            _journeyRepository = journeyRepository;
        }




        public void CreateJourney(JourneyDTO journey)
        {
            Journey newJourney = new Journey();

            newJourney.JourneyId = journey.JourneyId;
            newJourney.Date = journey.Date;
            newJourney.Works = null;

            _journeyRepository.Create(newJourney);
        }

        public bool DeleteJourney(long id)
        {
            Journey? journey = _journeyRepository.Get(id);
            if(journey == null) return false;
            _journeyRepository.Delete(journey);
            return true;
        }

        public Journey? GetJoureny(long id)
        {
            return _journeyRepository.Get(id);
        }

        public ICollection<Journey> GetJourneys()
        {
            return _journeyRepository.GetAll();
        }

        public bool UpdateJourney(long id, JourneyDTO journey)
        {
            Journey? journeyToUpdate = _journeyRepository.Get(id);
            if( journeyToUpdate == null ) return false;
            journeyToUpdate.JourneyId = id;
            journeyToUpdate.Date = journey.Date;

            _journeyRepository.Update(journeyToUpdate);
            return true;
        }
    }
}
