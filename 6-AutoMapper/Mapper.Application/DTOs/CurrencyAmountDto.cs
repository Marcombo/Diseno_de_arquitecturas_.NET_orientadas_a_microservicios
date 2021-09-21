namespace Mapper.Application.DTOs
{
    public class CurrencyAmountDto
    {
        public string Type { get; set; }

        public double Amount { get; set; }

        public string Text => $"{Amount} {Type}";
    }
}
