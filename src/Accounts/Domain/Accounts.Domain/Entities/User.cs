using Sev1.Accounts.Domain.Base;

namespace Sev1.Accounts.Domain
{
    public class User : EntityMutable<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string UserName { get; set; }
    }
}