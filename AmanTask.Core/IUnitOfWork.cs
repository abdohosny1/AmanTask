using AmanTask.Core.Model;
using AmanTask.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmanTask.Core
{
    public interface IUnitOfWork:IDisposable
    {
        IBaseRepository<Employee> Employees { get; }
        IBaseRepository<Department> Departments { get; }
        IEmployeeRepository EmployeeRepositoru { get; }

        int Complete();

    }
}
