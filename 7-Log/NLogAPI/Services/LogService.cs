using Microsoft.Extensions.Logging;

namespace NLogAPI.Services
{
    public interface ILogService {
        void Invoke();
    }

    public class LogService: ILogService
    {
        private readonly ILogger<LogService> _logger;

        public LogService(ILogger<LogService> logger) => _logger = logger;

        public void Invoke() => _logger.LogInformation("Invocada a llamada del servicio.");
    }
}
