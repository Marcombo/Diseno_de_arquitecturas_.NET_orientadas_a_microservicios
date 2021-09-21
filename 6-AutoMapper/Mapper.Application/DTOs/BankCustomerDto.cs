namespace Mapper.Application.DTOs
{
    public class BankCustomerDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public CurrencyAmountDto Currency { get; set; }

        public string FullName => $"{LastName} {FirstName}";
    }
}
