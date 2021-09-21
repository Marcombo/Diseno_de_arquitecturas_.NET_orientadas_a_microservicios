using System.Collections.Generic;
using System.Threading.Tasks;
using ms.employees.domain.Entities;

namespace ms.employees.domain.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployees();
        Task<string> UpdateAttendanceStateEmployee(string userName, bool attendance, string notes);
        Task<string> CreateEmployee(Employee employee);
        Task<Employee> GetEmployee(string userName);
    }
}
