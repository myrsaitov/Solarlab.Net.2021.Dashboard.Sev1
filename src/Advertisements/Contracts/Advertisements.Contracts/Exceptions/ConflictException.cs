using Sev1.Advertisements.Contracts.Exception.Base;

namespace Sev1.Advertisements.Contracts.Exception
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