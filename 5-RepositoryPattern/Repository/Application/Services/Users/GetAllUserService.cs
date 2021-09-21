using System.Collections.Generic;
using Repository.Domain.Entities;
using Repository.Domain.Interfaces.Repositories;
using Repository.Domain.Interfaces.Services.Users;

namespace Repository.Application.Services.Users
{
    public class GetAllUserService : IGetAllUserService
    {
        private readonly IUserRepository _repository;

        public GetAllUserService(IUserRepository repository) => _repository = repository;

        public List<User> GetAllUsers() => _repository.GetAll();
    }
}
