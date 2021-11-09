using Sev1.UserFiles.Contracts.Exceptions.Base;

namespace Sev1.UserFiles.Contracts.Exceptions
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