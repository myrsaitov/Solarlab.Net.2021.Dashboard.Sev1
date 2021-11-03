using System.Collections.Generic;

namespace UserFiles.Contracts.Contracts.User
{
    public class ValidateTokenResponse
    {
        public string UserId { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
