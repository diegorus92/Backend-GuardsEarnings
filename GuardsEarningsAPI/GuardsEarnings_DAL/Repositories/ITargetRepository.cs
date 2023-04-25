using GuardsEarnings_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardsEarnings_DAL.Repositories
{
    public interface ITargetRepository
    {
        public void Save();
        public void Create(Target entity);
        public void Delete(Target entity);
        public Target? Get(long id);
        public ICollection<Target> GetAll();
        public void Update(Target entity);

    }
}
