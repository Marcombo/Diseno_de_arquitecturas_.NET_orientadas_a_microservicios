using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ms.users.domain.Entities;
using ms.users.domain.Interfaces;

namespace ms.users.application.Commands.Handlers
{
    public class CreateUserAccountCommandHandler : IRequestHandler<CreateUserAccountCommand, string>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserAccountCommandHandler(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<string> Handle(CreateUserAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.CreateUser(
                new User() { UserName = request.UserName, Password = request.Password, Role = request.Role });
            return user.UserName;
        }
    }
}
