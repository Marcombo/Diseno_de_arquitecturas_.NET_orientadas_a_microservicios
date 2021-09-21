using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using JWT.API.Domain.Entities;
using JWT.API.Middlewares.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace JWT.API.Controllers
{
    [Authorize(Roles = "User,Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class TestAuthorizationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly TokenScopedDto _tokenScopedDto;
        public TestAuthorizationController(IConfiguration configuration, TokenScopedDto tokenScopedDto)
        {
            _configuration = configuration;
            _tokenScopedDto = tokenScopedDto;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetScopedTokenCall() => Ok(_tokenScopedDto);

        [HttpGet]
        [Route("[action]")]
        public ActionResult PrivateCall() {
            var userId= User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value;

            var userDataClaim = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.UserData);

            return Ok(new { Id = userId, userData = JsonSerializer.Deserialize<CredentialUser>(userDataClaim.Value) });
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult PrivateCallAlternative()
        {
            var identity = User.Identity as ClaimsIdentity;

            var userSerialized = (identity.FindFirst(ClaimTypes.UserData))?.Value;

            return Ok(JsonSerializer.Deserialize<CredentialUser>(userSerialized));
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult PrivateCallReadToken()
        {
            string jwtToken = Request.Headers["Authorization"].ToString().Substring(7);

            var jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(jwtToken);

            var claimUserData = jwtSecurityToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData)?.Value;

            return Ok(JsonSerializer.Deserialize<CredentialUser>(claimUserData));
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("[action]")]
        public ActionResult AnonymousCall() => Ok("Esta llamada es anónima");
    }
}


