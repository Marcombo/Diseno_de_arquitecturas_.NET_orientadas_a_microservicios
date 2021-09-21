using Microsoft.AspNetCore.Mvc;
using Repository.Domain.Interfaces.Services.Users;

namespace Repository.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    public class GetAllUserController : ControllerBase
    {
        private readonly IGetAllUserService _getAllUserService;

        public GetAllUserController(IGetAllUserService getAllUserService) => _getAllUserService = getAllUserService;

        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAllUsers() => Ok(_getAllUserService.GetAllUsers());
    }
}
