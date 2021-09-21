using System.Collections.Generic;
using MediatR;
using ms.users.application.Responses;

namespace ms.users.application.Queries
{
    public record GetAllUsersQuery() : IRequest<IEnumerable<UserResponse>>;
}
