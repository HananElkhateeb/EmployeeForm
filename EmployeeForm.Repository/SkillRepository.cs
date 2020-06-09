using EmployeeForm.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForm.Repository
{
   public class SkillRepository :GenericRepository<Skill>, ISkillRepository
    {
        public SkillRepository(DbContext context)
            : base(context)
        {

        }
        public Skill GetSkillById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
