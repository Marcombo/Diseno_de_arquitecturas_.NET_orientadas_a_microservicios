using Repository.Domain.Entities;

namespace Repository.Domain.Interfaces.Services.Users
{
    public interface IGetUserService
    {
        User GetUser(string userName);
    }
}
