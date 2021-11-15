using Sev1.Accounts.Domain.Base.Exceptions.Base;

namespace Sev1.Accounts.Domain.Base.Exceptions
{
    /// <summary>
    /// Доменное исключение при отсутствии прав
    /// </summary>
    public class NoRightsException : DomainException
    {
        public NoRightsException(string message) : base(message)
        {
        }
    }
}