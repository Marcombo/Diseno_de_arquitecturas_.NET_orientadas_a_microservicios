using System;
namespace SOLID.DIP.OK.DIP
{
    public interface IProductRepository
    {
        void Save(Product product);
    }
}
