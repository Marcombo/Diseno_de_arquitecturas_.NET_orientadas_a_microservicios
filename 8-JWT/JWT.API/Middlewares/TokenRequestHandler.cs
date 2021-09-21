using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using JWT.API.Domain.Entities;
using JWT.API.Middlewares.DTOs;
using Microsoft.AspNetCore.Http;

namespace JWT.API.Middlewares
{
    public class TokenRequestHandler
    {
        private readonly RequestDelegate _next;

        public TokenRequestHandler(RequestDelegate next) => _next = next;

        public async Task Invoke(HttpContext context, TokenScopedDto tokenScopedDto)
        {
            try {
                var requestStream = new MemoryStream();
                var originalRequest = context.Request.Body;
                await context.Request.Body.CopyToAsync(requestStream);

                requestStream.Seek(0, SeekOrigin.Begin);

                var requestBody = new StreamReader(requestStream).ReadToEnd();

                Console.WriteLine(requestBody);

                requestStream.Seek(0, SeekOrigin.Begin);
                context.Request.Body = requestStream;

                var token = context.Request.Headers.ContainsKey("Authorization") ?
                            context.Request.Headers["Authorization"].ToString() : null;

                if (token != null)
                {
                    string jwtToken = token.Substring(7);

                    var jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(jwtToken);

                    var claimUserData = jwtSecurityToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData)?.Value;

                    var role = jwtSecurityToken.Claims.FirstOrDefault(c =>
                                                                      c.Type == ClaimTypes.Role.Split("/").Last())?.Value;

                    CredentialUser credentialUser = JsonSerializer.Deserialize<CredentialUser>(claimUserData);

                    tokenScopedDto.Id = credentialUser.Id;
                    tokenScopedDto.UserName = credentialUser.UserName;
                    tokenScopedDto.Role = role;
                }

                Console.WriteLine(token);

                await _next(context);
            } catch{ throw; }
        }
    }
}
