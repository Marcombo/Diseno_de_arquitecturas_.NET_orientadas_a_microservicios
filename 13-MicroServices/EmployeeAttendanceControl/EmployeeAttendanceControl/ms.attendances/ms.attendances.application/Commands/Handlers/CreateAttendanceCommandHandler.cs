using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ms.attendances.domain.Entities;
using ms.attendances.domain.Repositories;
using ms.rabbitmq.Events;
using ms.rabbitmq.Producers;

namespace ms.attendances.application.Commands.Handlers
{
    public class CreateAttendanceCommandHandler : IRequestHandler<CreateAttendanceCommand, bool>
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IMapper _mapper;
        public CreateAttendanceCommandHandler(IAttendanceRepository attendanceRepository, IMapper mapper)
        {
            _attendanceRepository = attendanceRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateAttendanceCommand request, CancellationToken cancellationToken)
        {
            var attendanceRecord = _mapper.Map<AttendanceRecord>(request.AttendanceRequest);

            attendanceRecord.UserName = request.UserName;

            return await _attendanceRepository.CreateAttendance(attendanceRecord);
        }
    }
}


