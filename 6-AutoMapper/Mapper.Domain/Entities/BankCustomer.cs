namespace Mapper.Domain.Entities
{
    public class BankCustomer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public double CurrencyAmount { get; set; }

        public string CurrencyType { get; set; }

        public string Password { get; set; }
    }
}
