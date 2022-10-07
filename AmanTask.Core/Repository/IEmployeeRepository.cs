

using AmanTask.Core.Model;

namespace AmanTask.Core.Repository
{
    public interface IEmployeeRepository :IBaseRepository<Employee>
    {
        Task<IEnumerable<Employee>>GetAllEmployeeByDepartment( string name);
        Task<Employee>GetEmployeeBYID( int id);
    }
}
