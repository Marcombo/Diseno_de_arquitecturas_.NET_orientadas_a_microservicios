using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWT.API.Application.Services;
using JWT.API.Requests;
using Microsoft.AspNetCore.Mvc;

namespace JWT.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly ILoginAuthenticationService _loginAuthenticationService;
        public AuthController(ILoginAuthenticationService loginAuthenticationService)=>
            _loginAuthenticationService = loginAuthenticationService;
        
        [HttpPost]
        public ActionResult DoLogin([FromBody] LoginCredential credentials) =>
            Ok(_loginAuthenticationService.ValidateCredentials(credentials.UserName, credentials.Password));
    }
}
