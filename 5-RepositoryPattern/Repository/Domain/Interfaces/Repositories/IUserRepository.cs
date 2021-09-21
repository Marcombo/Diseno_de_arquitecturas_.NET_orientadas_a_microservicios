using System.Collections.Generic;
using Repository.Domain.Entities;

namespace Repository.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User Get(string userName);
        User Create(User user);
        User UpdateEmail(string userName, string email);
        void Delete(string userName);
    }
}
