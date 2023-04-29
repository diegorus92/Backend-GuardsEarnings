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
        private readonly IJourneyRepository _journeyRepository;

        public JourneyService(IJourneyRepository journeyRepository)
        {
            _journeyRepository = journeyRepository;
        }




        public Journey? CreateJourney(JourneyDTO journey)
        {
            //Firs search the journey if exist in the DB.
            Journey? journeySearch = _journeyRepository.GetByDate(journey.Date.Year, journey.Date.Month, journey.Date.Day); 

            if(journeySearch == null ) //if not exist in DB, then create it and return it
            {
                Journey newJourney = new Journey();

                newJourney.JourneyId = journey.JourneyId;
                newJourney.Date = journey.Date;
                newJourney.Works = null;

                return _journeyRepository.Create(newJourney);
            }
            else //otherwise, return the found journey
            {
                return journeySearch;
            }
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

        public Journey? GetJourneyByDate(int year, int month, int day)
        {
            return _journeyRepository.GetByDate(year, month, day);
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
