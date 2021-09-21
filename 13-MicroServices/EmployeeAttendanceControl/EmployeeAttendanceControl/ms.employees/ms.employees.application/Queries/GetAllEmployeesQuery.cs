using System.Collections.Generic;
using MediatR;
using ms.employees.application.Responses;

namespace ms.employees.application.Queries
{
    public record GetAllEmployeesQuery() : IRequest<IEnumerable<EmployeeResponse>>;
}
