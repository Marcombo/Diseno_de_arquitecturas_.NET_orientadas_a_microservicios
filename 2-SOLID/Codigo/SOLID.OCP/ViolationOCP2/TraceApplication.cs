using System;
using System.Threading.Tasks;

namespace SOLID.OCP.ViolationOCP2
{
    public class TraceApplication
    {
        public TraceApplication() { }

        public async Task Trace(ApplicationMessage applicationMessage)
        {
            switch (applicationMessage.Type)
            {
                case "Info":    // 1. Registrar en Log el mensaje
                    await RegisterInLog(applicationMessage.Text); break;   
                case "Error":   // 2. Enviar mail al equipo de desarrollo
                    await SendEmailToAdminInLog(applicationMessage.Text); break;
                case "Critical":// 3. Enviar por FTP el log al administrador del sistema
                    await SendLogToAFtp(); break;
                default:        // 4. Registrar en Log el mensaje
                    await RegisterInLog(applicationMessage.Text); break;
            }
        }

        private async Task RegisterInLog(string message) { }

        private async Task SendEmailToAdminInLog(string message) { }

        private async Task SendLogToAFtp() { }
    }
}