using MediatR;

namespace ms.users.application.Commands
{
    public record CreateUserAccountCommand(string UserName, string Password, string Role): IRequest<string>;
}
