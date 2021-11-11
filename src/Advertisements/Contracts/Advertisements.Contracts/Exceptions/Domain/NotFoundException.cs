using Sev1.Advertisements.Contracts.Exceptions.Domain.Base;

namespace Sev1.Advertisements.Contracts.Exceptions.Domain
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