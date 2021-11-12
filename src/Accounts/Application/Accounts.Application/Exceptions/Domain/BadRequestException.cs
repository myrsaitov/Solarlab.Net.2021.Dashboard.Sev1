using Sev1.Accounts.Application.Exceptions.Domain.Base;

namespace Sev1.Accounts.Application.Exceptions.Domain
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