using Mapper.Application.DTOs;
using Mapper.Domain.Entities;

namespace Mapper.Application.Services
{
    public interface IMapperService
    {
        BankCustomer ConvertToEntity(BankCustomerDto dto);

        BankCustomerDto ConvertToDto(BankCustomer entity);
    }
}
