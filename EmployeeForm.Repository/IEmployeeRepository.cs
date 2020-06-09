using EmployeeForm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForm.Repository
{
    interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Employee GetEmployeeById(int id);
    }
}
