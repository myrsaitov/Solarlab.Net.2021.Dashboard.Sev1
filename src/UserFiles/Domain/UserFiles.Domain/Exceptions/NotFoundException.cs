using Sev1.UserFiles.Domain.Base;

namespace Sev1.UserFiles.Domain.Exceptions
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