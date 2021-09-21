using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ms.employees.application.Commands;
using ms.employees.application.Queries;
using ms.employees.application.Requests;

namespace ms.employees.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator) => _mediator = mediator;

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllEmployees()
            => Ok(await _mediator.Send(new GetAllEmployeesQuery()));

        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeRequest employee) =>
            Ok(await _mediator.Send(new CreateEmployeeCommand(employee.UserName, employee.FirstName
                                                            , employee.LastName, employee.Password, employee.Role)));

        [Authorize]
        [HttpPut]
        [Route("[action]/{attendance}")]
        public async Task<IActionResult> UpdateAttendanceState(bool attendance,[FromBody] string notes) {
            var userName= User.Claims.FirstOrDefault(
                                        claim => claim.Type == ClaimTypes.NameIdentifier)?.Value;
            return Ok(await _mediator.Send(new UpdateAttendanceStateCommand(userName, attendance, notes
                                                        ,Request.Headers["Authorization"].ToString())));
        }
    }
}
