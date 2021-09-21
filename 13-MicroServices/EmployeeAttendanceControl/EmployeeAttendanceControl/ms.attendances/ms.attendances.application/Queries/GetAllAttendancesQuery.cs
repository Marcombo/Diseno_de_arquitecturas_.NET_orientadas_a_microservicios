using System;
using System.Collections.Generic;
using MediatR;
using ms.attendances.application.Responses;

namespace ms.attendances.application.Queries
{
    public record GetAllAttendancesQuery(string UserName)
        : IRequest<IEnumerable<AttendanceResponse>>;
}
