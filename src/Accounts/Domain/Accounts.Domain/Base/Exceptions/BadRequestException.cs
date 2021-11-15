using Sev1.Accounts.Domain.Base.Exceptions.Base;

namespace Sev1.Accounts.Domain.Base.Exceptions
{
    /// <summary>
    /// Несоответствующий запрос
    /// </summary>
    public class BadRequestException : DomainException
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
}