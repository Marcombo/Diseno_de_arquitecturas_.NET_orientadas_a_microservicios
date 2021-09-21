using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ms.employees.domain.Entities;
using ms.employees.domain.Repositories;
using ms.employees.infrastructure.Data;
using ms.employees.infrastructure.SqlData;

namespace ms.employees.infrastructure.Repositories
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private IDapperContext _employeeContext;
        public EmployeeRepository(IDapperContext employeeContext) => _employeeContext = employeeContext;

        public async Task<Employee> GetEmployee(string userName)
        {
            var res = await _employeeContext.Connection.QueryAsync<Employee>(EmployeeDataSql.GetEmployee,
                                                                             new { UserName = userName });
            return res?.FirstOrDefault();
        }

        public async Task<string> CreateEmployee(Employee employee) {
            var res = await _employeeContext.Connection.ExecuteAsync(EmployeeDataSql.Create,param:
                                   new { UserName = employee?.UserName, FirstName = employee?.FirstName,
                                         LastName = employee?.LastName, State     = employee?.LastAttendanceState,
                                         Notes    = employee?.LastAttendanceNotes });
            return res > 0 ? employee.UserName : throw new Exception("Usuario no creado");
        }

        public async Task<List<Employee>> GetAllEmployees() {
            var res=await _employeeContext.Connection.QueryAsync<Employee>(EmployeeDataSql.GetAll);
            return res?.ToList() ?? new List<Employee>();
        }

        public async Task<string> UpdateAttendanceStateEmployee(string userName, bool attendance, string notes) {
            var res = await _employeeContext.Connection.ExecuteAsync(EmployeeDataSql.UpdateAttendanceState, param:
                                   new { UserName = userName, State = attendance, Notes = notes });
            return res > 0 ? userName : null;
        }

        
    }
}
