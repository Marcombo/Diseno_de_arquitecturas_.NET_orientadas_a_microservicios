using System.Collections.Generic;
using System.Threading.Tasks;
using ms.users.domain.Entities;

namespace ms.users.domain.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUser(string userName,string password);
        Task<User> CreateUser(User user);
    }
}
