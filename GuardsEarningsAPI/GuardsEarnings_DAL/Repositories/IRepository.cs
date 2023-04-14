using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardsEarnings_DAL.Repositories
{
    public interface IRepository<T>
    {
        public void Create(T entity);
        public T Get(long id);
        public ICollection<T> GetAll();
        public void Update(T entity);
        public void Delete(T entity);
        public void Save();
    }
}
