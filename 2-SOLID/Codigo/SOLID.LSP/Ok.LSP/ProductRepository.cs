using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SOLID.LSP.Ok.LSP;
using SOLID.LSP.Violation.LSP;

namespace SOLID.LSP.Ok.LSP
{
    public class ProductRepository: ICreateGenericRepository<Product>
                                  , IReadGenericRepository<Product>
                                  , IUpdateGenericRepository<Product>
                                  , IDeleteGenericRepository<Product>
    {
        public ProductRepository() { }

        public async Task<string> AddAsync(Product entity) {
            return entity.Name;                     //Añadir producto
        }
        
        public async Task<IReadOnlyList<Product>> GetAllAsync() {
            return new List<Product>().AsReadOnly();//Listar productos
        }

        public async Task<Product> GetByIdAsync(string id) {
            return new Product();                   //Obtener un producto
        }

        public async Task<int> UpdateAsync(Product entity) {
            return 1;                               //Actualizar producto
        }

        public async Task<int> DeleteAsync(string id) {
            return 1;                               //Borrar Producto
        }

    }
}
