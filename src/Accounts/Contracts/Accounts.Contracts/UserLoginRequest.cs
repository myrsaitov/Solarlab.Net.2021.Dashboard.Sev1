using System.ComponentModel.DataAnnotations;

namespace Sev1.Accounts.Contracts
{
    public class UserLoginRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}