using Sev1.Accounts.AppServices.Exceptions.Domain;

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