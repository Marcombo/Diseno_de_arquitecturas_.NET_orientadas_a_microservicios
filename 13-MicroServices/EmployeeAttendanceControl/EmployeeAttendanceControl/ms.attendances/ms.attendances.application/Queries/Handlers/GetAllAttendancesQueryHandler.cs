using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ms.attendances.application.Responses;
using ms.attendances.domain.Repositories;

namespace ms.attendances.application.Queries.Handlers
{
    public class GetAllAttendancesQueryHandler : IRequestHandler<GetAllAttendancesQuery, IEnumerable<AttendanceResponse>>
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IMapper _mapper;

        public GetAllAttendancesQueryHandler(IAttendanceRepository attendanceRepository, IMapper mapper) {
            _attendanceRepository = attendanceRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AttendanceResponse>> Handle(GetAllAttendancesQuery request
                                                                , CancellationToken cancellationToken) {
            var attendances = await _attendanceRepository.GetAllAttendances(request.UserName);
            return _mapper.Map<IEnumerable<AttendanceResponse>>(attendances);
        }
    }
}
