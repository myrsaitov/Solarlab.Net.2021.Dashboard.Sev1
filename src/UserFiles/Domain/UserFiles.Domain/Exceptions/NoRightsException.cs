using Sev1.UserFiles.Domain.Base;

namespace Sev1.UserFiles.Domain.Exceptions
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