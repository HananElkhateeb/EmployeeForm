using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForm.Model
{
    public class Skill : Entity<int>
    {
        public string SkillName { get; set; }
        public virtual IEnumerable<Employee> Employees { get; set; }
    }
}
