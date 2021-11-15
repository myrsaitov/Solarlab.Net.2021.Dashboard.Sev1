using Sev1.Accounts.Domain.Base.Exceptions;

namespace Sev1.Accounts.AppServices.Services.User.Exceptions
{
    /// <summary>
    /// Исключение при ошибках регистрации нового пользователя
    /// </summary>
    public class UserRegisteredException : BadRequestException
    {
        public UserRegisteredException(string message) : base(message)
        {
        }
    }
}
