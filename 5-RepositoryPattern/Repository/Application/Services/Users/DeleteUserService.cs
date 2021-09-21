using Repository.Domain.Interfaces.Repositories;
using Repository.Domain.Interfaces.Services.Users;

namespace Repository.Application.Services.Users
{
    public class DeleteUserService : IDeleteUserService
    {
        private readonly IUserRepository _repository;

        public DeleteUserService(IUserRepository repository) => _repository = repository;

        public void DeleteUser(string userName)=>_repository.Delete(userName);
    }
}
