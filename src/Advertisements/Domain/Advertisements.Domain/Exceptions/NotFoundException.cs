using Sev1.Advertisements.Domain.Base;

namespace Sev1.Advertisements.Domain.Exceptions
{
    public abstract class NotFoundException : DomainException
    {
        protected NotFoundException(string message) : base(message)
        {
        }
    }
}