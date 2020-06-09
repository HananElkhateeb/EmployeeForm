using EmployeeForm.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForm.Repository
{
    class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DbContext context)
           : base(context)
        {

        }
        public Employee GetEmployeeById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
