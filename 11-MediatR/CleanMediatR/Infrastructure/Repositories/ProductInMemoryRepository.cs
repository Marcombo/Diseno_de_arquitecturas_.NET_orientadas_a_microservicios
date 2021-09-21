using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class ProductInMemoryRepository : IProductInMemoryRepository
    {
        private List<Product> _products;

        public ProductInMemoryRepository() => _products = new();

        public async Task<Product> Create(Product product)
        {
            if (_products.Any(p => p.Id == product.Id))
                throw new Exception("El producto ya está registrado.");

            _products.Add(product);

            return product;
        }

        public async Task<List<Product>> GetAll() => _products;   
    }
}
