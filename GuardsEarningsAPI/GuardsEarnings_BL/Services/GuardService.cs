using GuardsEarnings_BL.Dtos;
using GuardsEarnings_DAL.Models;
using GuardsEarnings_DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
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

        public void CreateGuard(GuardDTO guard)
        {
            Guard newGuard = new Guard();

            newGuard.GuardId = guard.GuardId;
            newGuard.Name = guard.Name;
            newGuard.Surname = guard.Surname;
            newGuard.Cellphone = guard.Cellphone;
            newGuard.Email = guard.Email;
            newGuard.Direction = guard.Direction;
            newGuard.Works = null;

            _repository.Create(newGuard);
        }

        public bool DeleteGuard(long id)
        {
            Guard? guard = _repository.Get(id);
            if (guard == null)
            {
                return false;
            }
            _repository.Delete(guard);
            return true;
        }

        public Guard? GetGuard(long id) 
        {
            return _repository.Get(id);
        }

        public ICollection<Guard> GetGuards() 
        {
            return _repository.GetAll();
        }

        public Guard? GetWorks(long guardId)
        {
            return _repository.GetWorkOfGuards(guardId);
        }

        public bool UpdateGuard(long id, GuardDTO guard)
        {
            Guard? guardToUpdate = _repository.Get(id);
            if (guardToUpdate == null)
                return false;
            guardToUpdate.Name = guard.Name;
            guardToUpdate.Surname= guard.Surname;
            guardToUpdate.Email = guard.Email;
            guardToUpdate.Cellphone = guard.Cellphone;
            guardToUpdate.Direction = guard.Direction;

            _repository.Update(guardToUpdate);
            return true;
        }
    }
}
