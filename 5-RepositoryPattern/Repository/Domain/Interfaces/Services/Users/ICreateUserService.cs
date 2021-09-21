using Repository.Domain.Entities;
namespace Repository.Domain.Interfaces.Services.Users
{
    public interface ICreateUserService {
        User CreateUser(User user);
    }
}
