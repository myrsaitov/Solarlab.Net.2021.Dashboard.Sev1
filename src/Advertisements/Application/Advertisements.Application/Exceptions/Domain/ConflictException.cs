using Sev1.Advertisements.Application.Exceptions.Domain.Base;

namespace Sev1.Advertisements.Application.Exceptions.Domain
{
    /// <summary>
    /// Доменное исключение при конфликте
    /// </summary>
    public class ConflictException : DomainException
    {
        public ConflictException(string message) : base(message)
        {
        }
    }
}