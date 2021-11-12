using Sev1.Accounts.Contracts.Exceptions.Domain.Base;

namespace Sev1.Accounts.Contracts.Exceptions.Domain
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