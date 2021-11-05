using System.Collections.Generic;

namespace Sev1.Advertisements.Contracts.Contracts.User
{
    public class ValidateTokenResponse
    {
        public string UserId { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
