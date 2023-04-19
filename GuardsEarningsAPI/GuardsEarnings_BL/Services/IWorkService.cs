using GuardsEarnings_BL.Dtos;
using GuardsEarnings_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardsEarnings_BL.Services
{
    public interface IWorkService
    {
        public bool CreateWork(WorkDTO work);
        public bool DeleteWork(long id);
        public bool UpdateWork(long id, WorkDTO work);
        public Work? GetWork(long id);
        public ICollection<Work> GetWorks();
    }
}
