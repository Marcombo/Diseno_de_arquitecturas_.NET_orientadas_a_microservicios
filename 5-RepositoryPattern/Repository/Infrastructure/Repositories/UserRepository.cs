using System;
using System.Collections.Generic;
using System.Linq;
using Repository.Domain.Entities;
using Repository.Domain.Interfaces.Repositories;

namespace Repository.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users;

        public UserRepository() => _users = new();

        public User Create(User user) {
            if (_users.Any(u => u.UserName.ToLowerInvariant() == user.UserName.ToLowerInvariant()))
                throw new Exception("No puede crear un usuario ya existente.");

            _users.Add(user);

            return user;
        }

        public void Delete(string userName) {
            var user = Get(userName);
            if (user != null) _users.Remove(user);
        }

        public User Get(string userName) => _users.Find(u => u.UserName.ToLowerInvariant() == userName.ToLowerInvariant());

        public List<User> GetAll() => _users;

        public User UpdateEmail(string userName, string email)
        {
            var userIndex = _users.FindIndex(u => u.UserName.ToLowerInvariant() == userName.ToLowerInvariant());
            if (userIndex == -1) throw new KeyNotFoundException();

            _users.ElementAt(userIndex).Email = email;
            return _users.ElementAt(userIndex);
        }
    }
}
