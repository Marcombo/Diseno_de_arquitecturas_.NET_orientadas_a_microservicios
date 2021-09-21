using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IProductInMemoryRepository
    {
        Task<Product> Create(Product product);

        Task<List<Product>> GetAll();
    }
}
