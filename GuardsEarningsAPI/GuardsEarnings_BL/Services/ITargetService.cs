using GuardsEarnings_BL.Dtos;
using GuardsEarnings_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardsEarnings_BL.Services
{
    public interface ITargetService
    {
        public void CreateTarget(TargetDTO target);
        public bool DeleteTarget(long id);
        public bool UpdateTarget(long id, TargetDTO target);
        public Target? GetTarget(long id);
        public ICollection<Target> GetTargets();
    }
}
