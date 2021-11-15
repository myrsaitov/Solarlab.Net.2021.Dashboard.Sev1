using Sev1.Accounts.AppServices.Exceptions.Domain.Base;

namespace Sev1.Accounts.AppServices.Exceptions.Domain
{
    /// <summary>
    /// Доменное исключение "Не найдено"
    /// </summary>
    public class NotFoundException : DomainException
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}