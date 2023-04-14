using GuardsEarnings_DAL.Models;
using GuardsEarnings_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardsEarnings_BL.Services
{
    public class GuardService:IGuardService
    {
        private readonly IRepository<Guard> _repository;

        public GuardService(IRepository<Guard> repository)
        {
            _repository = repository;
        }

        public void CreateGuard(Guard guard)
        {
            _repository.Create(guard);
        }

        public void DeleteGuard(Guard guard)
        {
            throw new NotImplementedException();
        }

        public Guard? GetGuard(long id) 
        {
            return _repository.Get(id);
        }

        public ICollection<Guard> GetGuards() 
        {
            return _repository.GetAll();
        }

        public void UpdateGuard(Guard guard)
        {
            throw new NotImplementedException();
        }
    }
}
