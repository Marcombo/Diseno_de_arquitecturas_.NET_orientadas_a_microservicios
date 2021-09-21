using System;
using System.ComponentModel.DataAnnotations;

namespace ms.users.application.Requests
{
    public class AccountRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }

    }
}
