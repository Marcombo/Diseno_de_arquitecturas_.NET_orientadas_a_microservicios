using System;
using SOLID.OCP.OkOCP1;

namespace SOLID.OCP.ViolationOCP
{
    public class VirtualShopOCP
    {
        public VirtualShopOCP() { }

        public double CalculateProductPrice(IShopProduct shopProduct)
        {
            return shopProduct.CalculatePrice();
        }
    }
}
