using System;

namespace Sev1.Advertisements.Domain.Base
{
    public class DomainException : ApplicationException
    {
        public DomainException(string message) : base(message)
        {
        }
    }
}