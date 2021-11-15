using Sev1.Advertisements.Domain.Base.Exceptions.Base;

namespace Sev1.Advertisements.Domain.Base.Exceptions
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