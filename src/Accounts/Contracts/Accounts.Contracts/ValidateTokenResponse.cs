using System.Collections.Generic;

namespace Sev1.Accounts.Contracts
{
    public class ValidateTokenResponse
    {
        public string UserId { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}