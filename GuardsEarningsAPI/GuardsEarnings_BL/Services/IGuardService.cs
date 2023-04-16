using GuardsEarnings_BL.Dtos;
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
        public void CreateGuard(GuardDTO guard);
        public bool DeleteGuard(long id);
        public bool UpdateGuard(long id, GuardDTO guard);
        public Guard? GetGuard(long id);
        public ICollection<Guard> GetGuards();
    }
}
