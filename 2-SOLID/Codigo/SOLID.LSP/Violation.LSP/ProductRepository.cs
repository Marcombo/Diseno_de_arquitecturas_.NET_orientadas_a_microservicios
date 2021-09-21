using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SOLID.LSP.Violation.LSP
{
    public class ProductRepository: IGenericRepository<Product>
    {
        public ProductRepository() { }

        public async Task<string> AddAsync(Product entity) {
            return entity.Name;
        }

        public async Task<IReadOnlyList<Product>> GetAllAsync() {
            //Listar productos
            return new List<Product>().AsReadOnly();
        }

        public async Task<Product> GetByIdAsync(string id) {
            //Obtener un producto
            return new Product();
        }

        public async Task<int> UpdateAsync(Product entity) {
            //Actualizar producto
            return 1;
        }

        public async Task<int> DeleteAsync(string id) {
            //Borrar Producto
            return 1;
        }
    }
}
