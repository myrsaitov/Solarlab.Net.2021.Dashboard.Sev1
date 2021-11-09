using Sev1.Accounts.Contracts.Exceptions.Base;

namespace Sev1.Accounts.Application.Exceptions.User
{
    public class UserUpdateException : DomainException
    {
        public UserUpdateException(string message) : base(message)
        {
        }
    }
}