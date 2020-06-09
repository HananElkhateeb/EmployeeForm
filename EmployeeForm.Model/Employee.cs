using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForm.Model
{
    public class Employee : AuditableEntity<int>
    {
        [Required(ErrorMessage = "Employee Name is required!")]
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }
    }
}
