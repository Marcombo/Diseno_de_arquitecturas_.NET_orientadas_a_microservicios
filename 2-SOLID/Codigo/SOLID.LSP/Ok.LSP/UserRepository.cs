using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SOLID.LSP.Violation.LSP;

namespace SOLID.LSP.Ok.LSP
{
    public class UserRepository : ICreateGenericRepository<User>
                                , IReadGenericRepository<User>
                                , IUpdateGenericRepository<User>
    {
        public UserRepository(){ }

        public async Task<string> AddAsync(User entity) {
            return entity.Login;                  //Añadir Usuario
        }
       
        public async Task<IReadOnlyList<User>> GetAllAsync() {
            return new List<User>().AsReadOnly(); //Listar Usuarios
        }

        public async Task<User> GetByIdAsync(string id) {
            return new User();                    //Obtener un Usuario
        }

        public async Task<int> UpdateAsync(User entity) {
            return 1;                             //Actualizar Usuario
        }

    }
}
