using System;

namespace Sev1.Advertisements.Domain.Shared.Exceptions
{
    public class DomainException : ApplicationException
    {
        public DomainException(string message) : base(message)
        {
        }
    }
}