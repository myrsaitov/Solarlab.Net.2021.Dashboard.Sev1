namespace Sev1.Advertisements.Domain.Shared.Exceptions
{
    public class NoRightsException : DomainException
    {
        public NoRightsException(string message) : base(message)
        {
        }
    }
}