using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SOLID.LSP.Violation.LSP
{
    public class UserRepository : IGenericRepository<User>
    {
        public UserRepository(){ }

        public async Task<string> AddAsync(User entity) {
            //Añadir Usuario
            return entity.Login;
        }


        public async Task<IReadOnlyList<User>> GetAllAsync() {
            //Listar Usuarios
            return new List<User>().AsReadOnly();
        }

        public async Task<User> GetByIdAsync(string id) {
            //Obtener un Usuario
            return new User();
        }

        public async Task<int> UpdateAsync(User entity) {
            //Actualizar Usuario
            return 1;
        }

        public Task<int> DeleteAsync(string id) {
            throw new Exception(@"No se puede eliminar,
                                  perderíamos datos de auditoria en BBDD.");
        }
    }
}
