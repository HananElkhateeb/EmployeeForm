using EmployeeForm.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForm.Repository
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private CompanyContext _companyContext;
        public DatabaseFactory()
        {
            Database.SetInitializer<CompanyContext>(null);
        }
        public CompanyContext Get()
        {
            return _companyContext ?? (_companyContext = new CompanyContext());
        }

        public void Dispose()
        {
            if (_companyContext != null)
                _companyContext.Dispose();
        }
    }
}
