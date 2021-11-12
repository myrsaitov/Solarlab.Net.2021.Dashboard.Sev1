using Sev1.UserFiles.Contracts.Exceptions.Base;

namespace Sev1.UserFiles.Contracts.Exceptions
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