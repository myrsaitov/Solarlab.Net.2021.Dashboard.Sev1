using Sev1.Accounts.Contracts.Exceptions.Domain.Base;

namespace Sev1.Accounts.Contracts.Exceptions.User
{
    /// <summary>
    /// Исключение при ошибках регистрации нового пользователя
    /// </summary>
    public class UserRegisteredException : DomainException
    {
        public UserRegisteredException(string message) : base(message)
        {
        }
    }
}
