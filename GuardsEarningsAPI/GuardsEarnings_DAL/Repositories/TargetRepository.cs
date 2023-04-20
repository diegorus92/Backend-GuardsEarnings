using GuardsEarnings_DAL.Data;
using GuardsEarnings_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardsEarnings_DAL.Repositories
{
    public class TargetRepository : IRepository<Target>
    {

        private readonly Context _context;

        public TargetRepository(Context context)
        {
            _context = context;
        }




        public void Create(Target entity)
        {
            _context.Targets.Add(entity);
            Save();
        }

        public void Delete(Target entity)
        {
            _context.Targets.Remove(entity);
            Save();
        }

        public Target? Get(long id)
        {
            Target? target = _context.Targets.Find(id);
            if (target == null)
            {
                return null;
            }
            return target;  
        }

        public ICollection<Target> GetAll()
        {
            ICollection<Target> targets = _context.Targets.ToList();
            return targets;
        }

        public Guard? GetWorkOfGuards(long guardId)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Target entity)
        {
            _context.Targets.Update(entity);
            Save();
        }
    }
}
