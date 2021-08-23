using System;

namespace sev1.Advertisements.Domain.Shared.Exceptions
{
    public class DomainException : ApplicationException
    {
        public DomainException(string message) : base(message)
        {
        }
    }
}