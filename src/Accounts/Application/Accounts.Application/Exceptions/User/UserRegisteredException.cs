using Sev1.Accounts.AppServices.Exceptions.Domain;

namespace Sev1.Accounts.AppServices.Exceptions.User
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
