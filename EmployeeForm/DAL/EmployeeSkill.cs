using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeForm.DAL
{
    public class EmployeeSkill
    {
        public int ID { get; set; }
        public int SkillID { get; set; }
        public int EmployeeID { get; set; }
        public string SkillName { get; set; }
    }
}