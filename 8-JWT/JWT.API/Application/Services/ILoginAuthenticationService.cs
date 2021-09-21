namespace JWT.API.Application.Services
{
    public interface ILoginAuthenticationService
    {
        string ValidateCredentials(string userName,string password);
    }
}
