using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using JWT.API.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace JWT.API.Application.Services
{
    public class LoginAuthenticationService : ILoginAuthenticationService
    {
        private List<CredentialUser> _applicationUsers =>
            new() { new CredentialUser() { Id = 1, FirstName = "Ramón", LastName = "Serrano",
                                           UserName = "ramon", Password = "1234"} };

        private readonly IConfiguration _configuration;

        public LoginAuthenticationService(IConfiguration configuration) => _configuration = configuration;

        public string ValidateCredentials(string userName, string password)
        {
            var user = _applicationUsers.Find(user => user.UserName == userName && user.Password == password);
            if (user == null) throw new System.Exception("Usuario inválido. Introduzca credenciales válidas.");

            var claims = new List<Claim>() {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),//El identificador de usuario
                new Claim(ClaimTypes.Name, user.UserName),//El nombre de usuario
                new Claim(ClaimTypes.UserData, JsonSerializer.Serialize(user)),//Datos del usuario serializados
                new Claim(ClaimTypes.Role,"Admin")//Rol del usuario
            };

            var privateKey = _configuration.GetValue<string>("Authentication:JWT:Key");

            var symetricSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(privateKey));

            var signingCredentials=new SigningCredentials(symetricSigningKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(_configuration.GetValue<int>("Authentication:JWT:ExpirationHours")),
                SigningCredentials = signingCredentials
            };
            
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
           
            return tokenHandler.WriteToken(token);
        }
    }
}
