using Sev1.Advertisements.Application.Exceptions.Domain.Base;

namespace Sev1.Advertisements.Application.Exceptions.Domain
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