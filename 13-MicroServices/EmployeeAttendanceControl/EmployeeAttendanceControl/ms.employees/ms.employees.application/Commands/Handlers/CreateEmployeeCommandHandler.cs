using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ms.employees.domain.Entities;
using ms.employees.domain.Repositories;
using ms.rabbitmq.Events;
using ms.rabbitmq.Producers;

namespace ms.employees.application.Commands.Handlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, string>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProducer _producer;
        private readonly IMapper _mapper;
        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IProducer producer,IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _producer = producer;
            _mapper = mapper;
        }
        public async Task<string> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var res=await _employeeRepository.CreateEmployee(new Employee {  UserName = request.UserName,
                                                                            FirstName = request.FirstName,
                                                                            LastName = request.LastName});
            _producer.Produce(_mapper.Map<EmployeeCreatedEvent>(request));
            
            return res;
        }
    }
}
