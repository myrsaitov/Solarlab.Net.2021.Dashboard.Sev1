using Sev1.Accounts.AppServices.Exceptions.Domain;

namespace Sev1.Accounts.AppServices.Exceptions.Identity
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