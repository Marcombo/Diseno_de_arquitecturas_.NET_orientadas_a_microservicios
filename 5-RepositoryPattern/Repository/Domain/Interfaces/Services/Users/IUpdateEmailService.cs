using Repository.Domain.Entities;

namespace Repository.Domain.Interfaces.Services.Users
{
    public interface IUpdateEmailService
    {
        User UpdateEmail(string userName,string email);
    }
}
