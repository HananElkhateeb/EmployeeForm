using EmployeeForm.Model;
using EmployeeForm.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForm.Service
{
   public class EmployeeService : EntityService<Employee>, IEmployeeService
    {
        IUnitOfWork _unitOfWork;
        IEmployeeRepository _employeeRepository;

        public EmployeeService(IUnitOfWork unitOfWork, IEmployeeRepository employeeRepository)
            : base(unitOfWork, employeeRepository)
        {
            _unitOfWork = unitOfWork;
            _employeeRepository = employeeRepository;
        }

        public Employee GetEmployeeById(int id)
        {
            return _employeeRepository.GetEmployeeById(id);
        }
    }
}
