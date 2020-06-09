using EmployeeForm.Model;
using EmployeeForm.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForm.Service
{
    class SkillService : EntityService<Skill>, ISkillService
    {
        IUnitOfWork _unitOfWork;
        ISkillRepository _skillRepository;

        public SkillService(IUnitOfWork unitOfWork, ISkillRepository skillRepository)
          : base(unitOfWork, skillRepository)
        {
            _unitOfWork = unitOfWork;
            _skillRepository = skillRepository;
        }

        public Skill GetSkillById(int id)
        {
            return _skillRepository.GetSkillById(id);
        }
    }
}
