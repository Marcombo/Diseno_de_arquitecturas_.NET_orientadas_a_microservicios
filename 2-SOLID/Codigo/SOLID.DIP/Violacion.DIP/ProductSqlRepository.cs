using System;
namespace SOLID.DIP.Violacion.DIP
{
    public class ProductSqlRepository
    {
        public ProductSqlRepository() { }

        public void Save(Product product){
            Console.WriteLine("Guardar producto en BD de Sql Server.");
        }
    }
}
