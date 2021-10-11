using Sev1.Accounts.Domain.Base;

namespace Sev1.Accounts.Application.Exceptions.User
{
    public class UserUpdateException : DomainException
    {
        public UserUpdateException(string message) : base(message)
        {
        }
    }
}
