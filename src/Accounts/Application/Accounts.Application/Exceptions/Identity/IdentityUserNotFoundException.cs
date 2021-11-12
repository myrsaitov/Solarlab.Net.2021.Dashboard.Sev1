using Sev1.Accounts.Application.Exceptions.Domain;

namespace Sev1.Accounts.Application.Exceptions.Identity
{
    /// <summary>
    /// Исключение, если не найден Identity User
    /// </summary>
    public class IdentityUserNotFoundException : NotFoundException
    {
        public IdentityUserNotFoundException(string message) : base(message)
        {
        }
    }
}