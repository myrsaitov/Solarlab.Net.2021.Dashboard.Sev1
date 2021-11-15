using Sev1.Accounts.Domain.Base.Exceptions;

namespace Sev1.Accounts.AppServices.Services.Identity.Exceptions
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