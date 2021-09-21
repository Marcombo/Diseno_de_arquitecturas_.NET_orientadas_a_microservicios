﻿using Repository.Domain.Entities;
using Repository.Domain.Interfaces.Repositories;
using Repository.Domain.Interfaces.Services.Users;

namespace Repository.Application.Services.Users
{
    public class GetUserService : IGetUserService
    {
        private readonly IUserRepository _repository;

        public GetUserService(IUserRepository repository) => _repository = repository;

        public User GetUser(string userName) => _repository.Get(userName);
    }
}
