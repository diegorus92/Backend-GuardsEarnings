using GuardsEarnings_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardsEarnings_DAL.Repositories
{
    public interface IJourneyRepository
    {
        public void Save();
        public Journey? Create(Journey entity);
        public void Delete(Journey entity);
        public Journey? Get(long id);
        public ICollection<Journey> GetAll();
        public Journey? GetByDate(int year, int month, int day);
        public void Update(Journey entity);

    }
}
