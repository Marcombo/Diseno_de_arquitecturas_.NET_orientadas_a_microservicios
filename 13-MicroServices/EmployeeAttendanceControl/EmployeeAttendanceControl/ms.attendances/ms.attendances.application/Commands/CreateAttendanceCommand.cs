using MediatR;
using ms.attendances.application.Request;

namespace ms.attendances.application.Commands
{
    public record CreateAttendanceCommand
                 (string UserName, CreateAttendanceRequest AttendanceRequest): IRequest<bool>;
}
