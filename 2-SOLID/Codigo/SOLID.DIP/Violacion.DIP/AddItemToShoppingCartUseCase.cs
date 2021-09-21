using System;
namespace SOLID.DIP.Violacion.DIP
{
    public class AddItemToShoppingCartUseCase
    {
        private readonly ProductSqlRepository _productSqlRepository;

        public AddItemToShoppingCartUseCase(ProductSqlRepository productSqlRepository)
        {
            _productSqlRepository = productSqlRepository;
        }

        public void Add(Product product)
        {
            _productSqlRepository.Save(product);
        }
    }
}
