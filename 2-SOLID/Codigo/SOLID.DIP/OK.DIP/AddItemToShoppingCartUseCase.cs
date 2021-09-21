using System;
namespace SOLID.DIP.OK.DIP
{
    public class AddItemToShoppingCartUseCase
    {
        private readonly IProductRepository _productRepository;

        public AddItemToShoppingCartUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Add(Product product)
        {
            _productRepository.Save(product);
        }
    }
}
