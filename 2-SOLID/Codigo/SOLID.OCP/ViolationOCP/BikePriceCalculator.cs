using System;
namespace SOLID.OCP.ViolationOCP
{
    public class BikePriceCalculator
    {
        private double Price { get; set; }
        private int Vat { get; set; }

        public BikePriceCalculator(double price, int vat)
        {
            Price = price;
            Vat = vat;
        }

        public double CalculatePrice() {
            return Price + (Price * Vat);
        }
    }
}
