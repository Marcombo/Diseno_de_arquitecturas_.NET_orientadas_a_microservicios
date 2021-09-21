using Microsoft.AspNetCore.Mvc;
using Repository.Domain.Entities;
using Repository.Domain.Interfaces.Services.Users;

namespace Repository.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    public class CreateUserController : ControllerBase
    {
        private readonly ICreateUserService _createUserService;

        public CreateUserController(ICreateUserService createUserService) => _createUserService = createUserService;

        [HttpPost]
        [Route("[action]")]
        public ActionResult CreateUser(User user) => Ok(_createUserService.CreateUser(user));
    }
}
