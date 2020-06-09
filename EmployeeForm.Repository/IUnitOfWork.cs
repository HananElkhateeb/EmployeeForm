﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForm.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }
}
