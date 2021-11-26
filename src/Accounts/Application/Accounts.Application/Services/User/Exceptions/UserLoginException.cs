using Sev1.Accounts.Domain.Base.Exceptions;

namespace Sev1.Accounts.AppServices.Services.User.Exceptions
{
    /// <summary>
    /// Исключение при аутентификации
    /// </summary>
    public class UserLoginException : NoRightsException
    {
        public UserLoginException(string message) : base(message)
        {
        }
    }
}
