using System;
namespace SOLID.DIP.OK.DIP
{
    public class ProductRedisRepository : IProductRepository
    {
        public ProductRedisRepository() { }

        public void Save(Product product){
            Console.WriteLine("Guardar producto en Caché Redis.");
        }
    }
}
