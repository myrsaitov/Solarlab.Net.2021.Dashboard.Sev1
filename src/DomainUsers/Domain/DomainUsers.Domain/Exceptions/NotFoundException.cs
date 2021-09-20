using Sev1.DomainUsers.Domain.Base;

namespace Sev1.DomainUsers.Domain.Exceptions
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