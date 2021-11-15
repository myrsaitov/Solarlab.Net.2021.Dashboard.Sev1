using Sev1.Accounts.AppServices.Exceptions.Domain.Base;

namespace Sev1.Accounts.AppServices.Exceptions.Domain
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