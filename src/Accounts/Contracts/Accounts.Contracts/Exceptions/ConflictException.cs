using Sev1.Accounts.Contracts.Exceptions.Base;

namespace Sev1.Accounts.Contracts.Exceptions
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