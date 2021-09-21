using AutoMapper;
using Mapper.Application.DTOs;
using Mapper.Domain.Entities;

namespace Mapper.Application.Services
{
    public class MapperService: IMapperService
    {
        private readonly IMapper _autoMapper;

        public MapperService(IMapper autoMapper) => _autoMapper = autoMapper;

        public BankCustomerDto ConvertToDto(BankCustomer entity) => _autoMapper.Map<BankCustomerDto>(entity);

        public BankCustomer ConvertToEntity(BankCustomerDto dto) => _autoMapper.Map<BankCustomer>(dto);
    }
}
