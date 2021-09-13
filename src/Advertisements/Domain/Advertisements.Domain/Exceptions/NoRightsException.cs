using Sev1.Advertisements.Domain.Base;

namespace Sev1.Advertisements.Domain.Exceptions
{
    public class NoRightsException : DomainException
    {
        public NoRightsException(string message) : base(message)
        {
        }
    }
}