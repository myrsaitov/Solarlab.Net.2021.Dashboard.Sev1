using Sev1.UserFiles.Domain.Base.Exceptions.Base;

namespace Sev1.UserFiles.Domain.Base.Exceptions
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