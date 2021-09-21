namespace SOLID.OCP.ViolationOCP
{
    public class WheelPriceCalculator
    {
        private double Price { get; set; }
        private int Vat { get; set; }

        public WheelPriceCalculator(double price, int vat)
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
