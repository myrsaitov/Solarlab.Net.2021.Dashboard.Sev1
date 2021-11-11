using Sev1.Accounts.Contracts.Exceptions.Domain.Base;

namespace Sev1.Accounts.Contracts.Exceptions.Domain
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