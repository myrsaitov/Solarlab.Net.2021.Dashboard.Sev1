using Sev1.Accounts.Contracts.Exceptions.Domain;

namespace Sev1.Accounts.Contracts.Exceptions.Identity
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
