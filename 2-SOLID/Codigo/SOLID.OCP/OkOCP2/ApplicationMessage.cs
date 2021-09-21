using System.Threading.Tasks;

namespace SOLID.OCP.OkOCP2
{
    public class InfoMessage : IActionMessage
    {
        public string Text { get; set; }

        public Task DoAction(){ } //Registrar en Log el mensaje
    }
    public class ErrorMessage : IActionMessage
    {
        public string Text { get; set; }

        public Task DoAction() { } //Enviar mail al equipo de desarrollo 
    }
    public class CriticalMessage : IActionMessage
    {
        public string Text { get; set; }

        public Task DoAction() { } //Enviar por FTP el log al administrador del sistema
        
    }
}