using Sev1.Accounts.Contracts.Exceptions.Base;

namespace Sev1.Accounts.Application.Exceptions.User
{
    public class UserRegisteredException : DomainException
    {
        public UserRegisteredException(string message) : base(message)
        {
        }
    }
}
