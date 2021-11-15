using Sev1.Accounts.Domain.Base.Exceptions;

namespace Sev1.Accounts.AppServices.Exceptions.User
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