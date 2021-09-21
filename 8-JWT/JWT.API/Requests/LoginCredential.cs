using System.ComponentModel.DataAnnotations;

namespace JWT.API.Requests
{
    public class LoginCredential
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
