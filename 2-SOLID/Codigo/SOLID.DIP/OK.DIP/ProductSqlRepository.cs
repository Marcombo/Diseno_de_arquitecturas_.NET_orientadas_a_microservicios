using System;
namespace SOLID.DIP.OK.DIP
{
    public class ProductSqlRepository : IProductRepository
    {
        public ProductSqlRepository() { }

        public void Save(Product product){
            Console.WriteLine("Guardar producto en BD de Sql Server.");
        }
    }
}
