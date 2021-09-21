using AutoMapper;
using Mapper.Application.DTOs;
using Mapper.Domain.Entities;

namespace Mapper.Application.Mapper
{
    public class CustomerMapperProfile :Profile
    {
        public CustomerMapperProfile()
        {
            CreateMap<BankCustomer, BankCustomerDto>()
            .ForMember(dest => dest.FirstName, source => source.MapFrom(source => source.Name))
            .ForMember(dest => dest.Currency, source =>source.MapFrom(source =>
                new CurrencyAmountDto() { Amount = source.CurrencyAmount, Type = source.CurrencyType }))
            .ReverseMap();
        }
    }
}
