using Microsoft.AspNetCore.Mvc;
using Repository.Domain.Interfaces.Services.Users;

namespace Repository.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    public class GetUserController : ControllerBase
    {
        private readonly IGetUserService _getUserService;

        public GetUserController(IGetUserService getUserService) => _getUserService = getUserService;

        [HttpGet]
        [Route("[action]")]
        public ActionResult GetUser(string userName) => Ok(_getUserService.GetUser(userName));
    }
}
