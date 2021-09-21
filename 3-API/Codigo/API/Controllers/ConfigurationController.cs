using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ConfigurationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetText()
        {
            return Ok(_configuration.GetValue<string>("Text"));
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetSubProperty()
        {
            return Ok(_configuration.GetValue<string>("JsonFile:Name"));
        }
    }
}
