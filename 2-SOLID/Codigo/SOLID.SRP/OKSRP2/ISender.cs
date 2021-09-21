using System.Threading.Tasks;

namespace SOLID.SRP
{
    public interface ISender
    {
        public Task SendTo(User user);
    }
    public class SendWelcomeMessageByPushNotification : ISender
    {
        public async Task SendTo(User user)
        {
            //Envia Notificación Push al móvil destino -> user.Phone
        }
    }
    public class SendWelcomeMessageByEmail : ISender
    {
        public async Task SendTo(User user)
        {
            //Envia Email a email destino -> user.Email
        }
    }
}
