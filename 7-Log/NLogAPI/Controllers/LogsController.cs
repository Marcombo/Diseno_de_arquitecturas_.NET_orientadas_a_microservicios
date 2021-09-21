using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLogAPI.Services;

namespace NLogAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogsController : ControllerBase
    {
        private readonly ILogger<LogsController> _logger;
        private readonly ILogService _logService;
        public LogsController(ILogger<LogsController> logger, ILogService logService)
        {
            _logger = logger;
            _logService = logService;
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult GetLog(int id,string parameter,[FromBody] string name)
        {
            try
            {
                HttpContext.Items["userName"] = "Ramón";

                _logger.LogInformation($"Desde Url {HttpContext.Request.GetTypedHeaders().Referer} e IP:" +
                                $"{HttpContext.Request.HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString()}");

                _logger.LogInformation($"Enviada solicitud al controlador=>id:{id},parameter:{parameter},name:{name}");

                _logService.Invoke();

                throw new System.Exception("Esto es un error controlado");
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }
    }
}
