using System;
using System.ComponentModel.DataAnnotations;

namespace ms.users.application.Requests
{
    public class LoginCredentialsRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
