using Sev1.Advertisements.Contracts.Exception.Base;

namespace Sev1.Advertisements.Contracts.Exception
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