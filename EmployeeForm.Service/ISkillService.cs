using EmployeeForm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForm.Service
{
    public interface ISkillService : IEntityService<Skill>
    {
        Skill GetSkillById(int id);
    }
}
