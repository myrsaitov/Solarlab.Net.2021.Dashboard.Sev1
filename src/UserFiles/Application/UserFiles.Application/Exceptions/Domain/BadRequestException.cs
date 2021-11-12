using Sev1.UserFiles.Application.Exceptions.Domain.Base;

namespace Sev1.UserFiles.Application.Exceptions.Domain
{
    /// <summary>
    /// Несоответствующий запрос
    /// </summary>
    public class BadRequestException : DomainException
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
}