using Sev1.Accounts.Contracts.Exceptions;

namespace Sev1.Accounts.Application.Exceptions.Identity
{
    public class RoleNotFoundException : NotFoundException
    {
        public RoleNotFoundException(string message) : base(message)
        {
        }
    }
}
