using EmployeeForm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForm.Service
{
    public interface IEntityService<T> : IService
        where T : BaseEntity
    {
        void Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        void Update(T entity);
    }
}
