using System;
using System.Threading.Tasks;
using SOLID.OCP.OkOCP2;

namespace SOLID.OCP.ViolationOCP2
{
    public class TraceApplicationOCP
    {
        public TraceApplicationOCP() { }

        public void Trace(IActionMessage actionMessage)
        {
            actionMessage.DoAction();
        }
    }
}