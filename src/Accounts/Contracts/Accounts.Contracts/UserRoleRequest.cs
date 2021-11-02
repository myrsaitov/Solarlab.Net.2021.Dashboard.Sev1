using System.ComponentModel.DataAnnotations;

namespace Sev1.Accounts.Contracts
{
    public class UserRoleRequest
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Role { get; set; }
    }
}