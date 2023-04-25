using GuardsEarnings_DAL.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardsEarnings_DAL.Repositories
{
    public interface IWorkRepository
    {
        public void Save();
        public void Create(Work entity);
        public void Delete(Work entity);
        public Work? Get(long id);
        public ICollection<Work> GetAll();
        public void Update(Work entity);
        public void UpdateCompleteWork(Work entity, long guardId, long targetId, long journeyId);
        public ICollection<Work> SearchWorksByGuardAndDate(long guardId, int year, int month);
    }
}
