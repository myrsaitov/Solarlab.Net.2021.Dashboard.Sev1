using Sev1.Accounts.Domain.Exceptions;

namespace Sev1.Accounts.Application.Exceptions.User
{
    public sealed class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(string message) : base(message)
        {

        }
    }
}