using Microsoft.AspNetCore.Mvc;
using Repository.Domain.Interfaces.Services.Users;

namespace Repository.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    public class DeleteUserController : ControllerBase
    {
        private readonly IDeleteUserService _deleteUserService;

        public DeleteUserController(IDeleteUserService deleteUserService) => _deleteUserService = deleteUserService;
        
        [HttpDelete]
        [Route("[action]/{userName}")]
        public ActionResult DeleteUser(string userName) { _deleteUserService.DeleteUser(userName);
            return Ok();
        }
    }
}
