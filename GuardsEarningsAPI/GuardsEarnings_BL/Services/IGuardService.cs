using GuardsEarnings_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardsEarnings_BL.Services
{
    public interface IGuardService
    {
        public void CreateGuard(Guard guard);
        public void DeleteGuard(Guard guard);
        public void UpdateGuard(Guard guard);
        public Guard GetGuard(long id);
        public ICollection<Guard> GetGuards();
    }
}
