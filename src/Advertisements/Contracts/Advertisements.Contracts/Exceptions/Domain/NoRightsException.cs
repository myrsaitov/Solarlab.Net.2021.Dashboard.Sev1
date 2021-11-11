using Sev1.Advertisements.Contracts.Exceptions.Domain.Base;

namespace Sev1.Advertisements.Contracts.Exceptions.Domain
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