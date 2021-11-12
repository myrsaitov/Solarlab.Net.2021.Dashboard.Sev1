using Sev1.Accounts.Application.Exceptions.Domain;

namespace Sev1.Accounts.Application.Exceptions.User
{
    /// <summary>
    /// Исключение, если не найден доменный пользователь
    /// </summary>
    public sealed class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(string message) : base(message)
        {

        }
    }
}