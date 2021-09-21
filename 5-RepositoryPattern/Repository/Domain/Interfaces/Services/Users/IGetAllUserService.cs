using System.Collections.Generic;
using Repository.Domain.Entities;

namespace Repository.Domain.Interfaces.Services.Users
{
    public interface IGetAllUserService
    {
        List<User> GetAllUsers();
    }
}
