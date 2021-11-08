using System.ComponentModel.DataAnnotations;

namespace Sev1.Accounts.Contracts
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string UserName { get; set; }
    }
}