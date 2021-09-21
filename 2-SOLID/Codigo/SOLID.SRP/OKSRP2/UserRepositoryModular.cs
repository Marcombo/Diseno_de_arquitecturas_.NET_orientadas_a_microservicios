using System.Threading.Tasks;

namespace SOLID.SRP
{
    public class UserRepositoryModular
    {
        private readonly ISender _sender;

        public UserRepositoryModular(ISender sender) => _sender = sender;

        public async Task Register(User user)
        {
            //1. Crear registro de usuario en BBDD

            //2. Enviar credenciales al usuario al mail o teléfono
            await _sender.SendTo(user);
        }

    }
}


