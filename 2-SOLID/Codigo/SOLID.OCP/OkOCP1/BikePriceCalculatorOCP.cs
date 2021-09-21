using SOLID.OCP.OkOCP1;

namespace SOLID.OCP.ViolationOCP
{
    public class BikePriceCalculatorOCP: IShopProduct
    {
        private double Price { get; set; }
        private int Vat { get; set; }

        public BikePriceCalculatorOCP(double price, int vat)
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
