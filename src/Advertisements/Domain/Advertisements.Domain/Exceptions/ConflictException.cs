using Sev1.Advertisements.Domain.Base;

namespace Sev1.Advertisements.Domain.Exceptions
{
    public class ConflictException : DomainException
    {
        public ConflictException(string message) : base(message)
        {
        }
    }
}