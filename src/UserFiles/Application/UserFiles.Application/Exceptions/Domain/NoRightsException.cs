using Sev1.UserFiles.Application.Exceptions.Domain.Base;

namespace Sev1.UserFiles.Application.Exceptions.Domain
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