using System.Threading.Tasks;

namespace SOLID.SRP
{
    public class UserRepositorySrpViolation
    {
        public UserRepositorySrpViolation() { }

        public async Task Register(User user)
        {
            //1. Crear registro de usuario en BBDD

            //2. Enviar credenciales al usuario al mail
            await SendWelcomeMessageToMail(user.EMail);
        }
        public async Task SendWelcomeMessageToMail(string email)
        {
            //Enviar Mensaje de bienvenida al usuario
        }
    }
}
