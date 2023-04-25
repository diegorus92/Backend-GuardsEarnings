using GuardsEarnings_BL.Dtos;
using GuardsEarnings_DAL.Models;
using GuardsEarnings_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardsEarnings_BL.Services
{
    public class TargetService : ITargetService
    {
        private readonly ITargetRepository _targetRepository;

        public TargetService(ITargetRepository targetRepository)
        {
            _targetRepository = targetRepository;
        }




        public void CreateTarget(TargetDTO target)
        {
            Target newTarget = new Target();

            newTarget.TargetId = target.TargetId;
            newTarget.Name = target.Name;
            newTarget.Type = target.Type;
            newTarget.Payment = target.Payment;
            newTarget.Direction = target.Direction;
            newTarget.Notes = target.Notes;
            newTarget.Works = null;

            _targetRepository.Create(newTarget);
        }

        public bool DeleteTarget(long id)
        {
            Target? target = _targetRepository.Get(id); 
            if(target == null)
            {
                return false;
            }
            _targetRepository.Delete(target);
            return true;
        }

        public Target? GetTarget(long id)
        {
            return _targetRepository.Get(id);
        }

        public ICollection<Target> GetTargets()
        {
            return _targetRepository.GetAll();
        }

        public bool UpdateTarget(long id, TargetDTO target)
        {
            Target? targetToUpdate = _targetRepository.Get(id);
            if(targetToUpdate == null)
            {
                return false;
            }
            targetToUpdate.TargetId = id;
            targetToUpdate.Name = target.Name;
            targetToUpdate.Type = target.Type;
            targetToUpdate.Payment = target.Payment;
            targetToUpdate.Direction = target.Direction;
            targetToUpdate.Notes = target.Notes;

            _targetRepository.Update(targetToUpdate);
            return true;
        }
    }
}
