using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ms.employees.application.Responses;
using ms.employees.domain.Repositories;

namespace ms.employees.application.Queries.Handlers
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper) {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeResponse>> Handle(GetAllEmployeesQuery request
                                                                , CancellationToken cancellationToken) {
            var employees = await _employeeRepository.GetAllEmployees();
            return _mapper.Map<IEnumerable<EmployeeResponse>>(employees);
        }
    }
}
