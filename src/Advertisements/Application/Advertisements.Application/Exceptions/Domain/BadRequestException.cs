using Sev1.Advertisements.AppServices.Exceptions.Domain.Base;

namespace Sev1.Advertisements.AppServices.Exceptions.Domain
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