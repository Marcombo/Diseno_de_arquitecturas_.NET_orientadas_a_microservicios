using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ms.employees.application.HttpCommunications;
using ms.employees.domain.Repositories;
using ms.rabbitmq.Events;
using ms.rabbitmq.Producers;

namespace ms.employees.application.Commands.Handlers
{
    public class UpdateAttendanceStateCommandHandler : IRequestHandler<UpdateAttendanceStateCommand, string>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProducer _producer;
        private readonly IMapper _mapper;
        private readonly IAttendanceApiCommunication _attendanceApiCommunication;
        public UpdateAttendanceStateCommandHandler(IEmployeeRepository employeeRepository,
                                                   IProducer producer, IMapper mapper,
                                                   IAttendanceApiCommunication attendanceApiCommunication)
        {
            _employeeRepository = employeeRepository;
            _producer = producer;
            _mapper = mapper;
            _attendanceApiCommunication = attendanceApiCommunication;
        }

        public async Task<string> Handle(UpdateAttendanceStateCommand request,
                                         CancellationToken cancellationToken) {
            var userAttendances = await _attendanceApiCommunication.
                                            GetAllAttendances(request.UserName, request.Token);
            var numberOfAttendances = userAttendances.Count();

            string notes = request.Notes == null ? $"[{numberOfAttendances} Asistencias]"
                                       : String.Concat(request.Notes, $" [{numberOfAttendances} Asistencias]");
            var res = await _employeeRepository.UpdateAttendanceStateEmployee(request.UserName,
                                                                           request.Attendance, notes);
            var employee = await _employeeRepository.GetEmployee(request.UserName);

            _producer.Produce(_mapper.Map<AttendanceStateChangedEvent>(employee));
            return res;
        }
    }
}
