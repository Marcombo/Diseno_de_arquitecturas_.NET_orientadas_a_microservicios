using Repository.Domain.Entities;
using Repository.Domain.Interfaces.Repositories;
using Repository.Domain.Interfaces.Services.Users;

namespace Repository.Application.Services.Users
{
    public class UpdateEmailService : IUpdateEmailService
    {
        private readonly IUserRepository _repository;

        public UpdateEmailService(IUserRepository repository) => _repository = repository;

        public User UpdateEmail(string userName, string email) => _repository.UpdateEmail(userName, email);
    }
}
