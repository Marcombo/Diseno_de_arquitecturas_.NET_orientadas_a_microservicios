using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ms.users.application.Queries;
using ms.users.application.Requests;
namespace ms.users.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthenticationController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> DoLogin([FromBody] LoginCredentialsRequest loginCredentials) =>
            Ok(await _mediator.Send(new GetUserTokenQuery(loginCredentials.UserName, loginCredentials.Password)));
    }
}
