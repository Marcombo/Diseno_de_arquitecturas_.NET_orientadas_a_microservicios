using Microsoft.AspNetCore.Mvc;
using Repository.Domain.Interfaces.Services.Users;

namespace Repository.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    public class UpdateEmailController : ControllerBase
    {
        private readonly IUpdateEmailService _updateEmailService;

        public UpdateEmailController(IUpdateEmailService updateEmailService) =>
            _updateEmailService = updateEmailService;

        [HttpPut]
        [Route("[action]/{userName}")]
        public ActionResult UpdateEmail(string userName, string email) =>
            Ok(_updateEmailService.UpdateEmail(userName, email));
    }
}
