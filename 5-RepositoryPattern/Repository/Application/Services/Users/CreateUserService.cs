using Repository.Domain.Entities;
using Repository.Domain.Interfaces.Repositories;
using Repository.Domain.Interfaces.Services.Users;

namespace Repository.Application.Services.Users
{
    public class CreateUserService : ICreateUserService
    {
        private readonly IUserRepository _repository;

        public CreateUserService(IUserRepository repository) => _repository = repository;

        public User CreateUser(User user) => _repository.Create(user);
    }
}
