using Sev1.Accounts.Domain.Base.Exceptions;

namespace Sev1.Accounts.AppServices.Services.Identity.Exceptions
{
    /// <summary>
    /// Исключение, если не найдена роль
    /// </summary>
    public class RoleNotFoundException : NotFoundException
    {
        public RoleNotFoundException(string message) : base(message)
        {
        }
    }
}
