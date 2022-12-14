using Sev1.Advertisements.Domain.Base.Exceptions.Base;

namespace Sev1.Advertisements.Domain.Base.Exceptions
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