using Sev1.Accounts.Contracts.Exceptions.Base;

namespace Sev1.Accounts.Contracts.Exceptions
{
    /// <summary>
    /// Доменное исключение "Не найдено"
    /// </summary>
    public abstract class NotFoundException : DomainException
    {
        protected NotFoundException(string message) : base(message)
        {
        }
    }
}