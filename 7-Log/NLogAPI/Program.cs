using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace NLogAPI
{
    public class Program
    {
        public static void Main(string[] args) {

            NLog.GlobalDiagnosticsContext.Set("LogRootPath"
                , Path.Combine(Directory.GetCurrentDirectory(), "Logs"));

            var logger = NLog.Web.NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();

            try {
                logger.Debug("La Aplicación se está inicializando...");

                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex) {
                logger.Error(ex.Message);
            }
            finally {
                NLog.LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Trace);
                }).UseNLog();
    }
}
