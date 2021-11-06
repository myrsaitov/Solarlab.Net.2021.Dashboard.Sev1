using Sev1.UserFiles.Contracts.Exceptions.Base;

namespace Sev1.UserFiles.Contracts.Exceptions
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