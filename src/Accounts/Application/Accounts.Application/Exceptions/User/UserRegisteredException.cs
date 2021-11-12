using Sev1.Accounts.Application.Exceptions.Domain;

namespace Sev1.Accounts.Application.Exceptions.User
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
