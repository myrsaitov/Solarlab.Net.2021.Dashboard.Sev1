using Sev1.Accounts.Domain.Base;

namespace Sev1.Accounts.Domain.Exceptions
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