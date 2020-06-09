using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForm.Model
{
    public class CompanyInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CompanyContext>
    {
        protected override void Seed(CompanyContext context)
        {
            var employees = new List<Employee>
            {
                new Employee{EmployeeName="employee1",EmployeeEmail="employee1@company.com"}
            };
            employees.ForEach(e => context.Employees.Add(e));
            context.SaveChanges();

            var skills = new List<Skill>
            {
                new Skill{SkillName="PHP"},
                new Skill{SkillName="ASP.NET"},
                new Skill{SkillName="IOS"},
                new Skill{SkillName="Android"}
            };
            skills.ForEach(s => context.Skills.Add(s));
            context.SaveChanges();
        }
    }
}
