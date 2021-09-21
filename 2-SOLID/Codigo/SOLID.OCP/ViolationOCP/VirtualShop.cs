using System;
namespace SOLID.OCP.ViolationOCP
{
    public class VirtualShop
    {
        public VirtualShop() { }

        public double CalculateProductPrice(BikePriceCalculator bikePriceCalculator)
        {
            return bikePriceCalculator.CalculatePrice();
        }
    }
}
