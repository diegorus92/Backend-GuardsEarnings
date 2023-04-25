using GuardsEarnings_DAL.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardsEarnings_DAL.Repositories
{
    public interface IGuardRepository
    {
        public void Save();
        public void Create(Guard entity);
        public void Delete(Guard entity);
        public Guard? Get(long id);
        public ICollection<Guard> GetAll();
        public void Update(Guard entity);
        public Guard? GetWorkOfGuards(long guardId);

    }
}
