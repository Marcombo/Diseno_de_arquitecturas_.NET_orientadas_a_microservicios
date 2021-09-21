using System.Threading.Tasks;

namespace SOLID.OCP.OkOCP2
{
    public interface IActionMessage
    {
        public Task DoAction();
    }
}