using MediatR;

namespace ms.users.application.Queries
{
    public record GetUserTokenQuery(string UserName,string Password) : IRequest<string>;
}
