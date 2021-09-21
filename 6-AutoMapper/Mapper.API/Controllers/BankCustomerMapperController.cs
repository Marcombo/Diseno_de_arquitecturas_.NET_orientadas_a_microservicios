using Mapper.Application.DTOs;
using Mapper.Application.Services;
using Mapper.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Mapper.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankCustomerMapperController : ControllerBase
    {
        private readonly IMapperService _mapperService;

        public BankCustomerMapperController(IMapperService mapperService) => _mapperService = mapperService;

        private BankCustomer _entity => new BankCustomer() { Id = 1,
                                                             Age = 36,
                                                             CurrencyAmount = 1000,
                                                             CurrencyType="EUR",
                                                             LastName = "Serrano Valero",
                                                             Name = "Ramón",
                                                             Password = "1234" };
        [HttpGet]
        public ActionResult<BankCustomerDto> Get() => Ok(_mapperService.ConvertToDto(_entity));

        [HttpPost]
        public ActionResult<BankCustomer> CreateCustomer([FromBody] BankCustomerDto customerDto) =>
            Ok(_mapperService.ConvertToEntity(customerDto));
    }
}
