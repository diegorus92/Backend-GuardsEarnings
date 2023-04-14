using GuardsEarnings_DAL.Data;
using GuardsEarnings_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GuardsEarnings_DAL.Repositories
{
    public class GuardRepository: IRepository<Guard>
    {
        private readonly Context _context;

        public GuardRepository(Context context)
        {
            _context = context;
        }


        public void Save()
        {
            _context.SaveChanges();
        }

        public void Create(Guard entity)
        {
            _context.Guards.Add(entity);
            this.Save();
        }

        public void Delete(Guard entity)
        {
            _context.Guards.Remove(entity);
            this.Save();
        }

        public Guard Get(long id)
        {
            Guard? guard = _context.Guards.Find(id);
            if(guard == null)
            {
                throw new NullReferenceException("Guard not found with id: "+id);
            }
            return guard;
        }

        public ICollection<Guard> GetAll()
        {
            ICollection<Guard> guards = _context.Guards.ToList();
            return guards;
        }

        public void Update(Guard entity)
        {
            _context.Guards.Update(entity);
            this.Save();
        }
    }
}
