using System.Threading.Tasks;

namespace SOLID.SRP
{
    public class UserRepository
    {
        private readonly EmailSenderWelcomeMessage _emailSenderWelcomeMessage;

        public UserRepository(EmailSenderWelcomeMessage emailSenderWelcomeMessage)
        {
            _emailSenderWelcomeMessage = emailSenderWelcomeMessage;
        }

        public async Task Register(User user)
        {
            //1. Crear registro de usuario en BBDD

            //2. Enviar credenciales al usuario al mail
            await _emailSenderWelcomeMessage.SendWelcomeMessageToMail(user.EMail);
        }

    }
}


