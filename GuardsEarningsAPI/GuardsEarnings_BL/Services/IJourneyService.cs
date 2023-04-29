using GuardsEarnings_BL.Dtos;
using GuardsEarnings_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardsEarnings_BL.Services
{
    public interface IJourneyService
    {
        public Journey? CreateJourney(JourneyDTO journey);
        public bool DeleteJourney(long id);
        public bool UpdateJourney(long id, JourneyDTO journey);
        public Journey? GetJoureny(long id);
        public ICollection<Journey> GetJourneys();
        public Journey?GetJourneyByDate(int year, int month, int day);
    }
}
