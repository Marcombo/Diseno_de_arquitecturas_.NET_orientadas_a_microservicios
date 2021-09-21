using SOLID.OCP.OkOCP1;

namespace SOLID.OCP.ViolationOCP
{
    public class WheelPriceCalculatorOCP: IShopProduct
    {
        private double Price { get; set; }
        private int Vat { get; set; }

        public WheelPriceCalculatorOCP(double price, int vat)
        {
            Price = price;
            Vat = vat;
        }

        public double CalculatePrice()
        {
            return Price + (Price * Vat);
        }
    }
}
