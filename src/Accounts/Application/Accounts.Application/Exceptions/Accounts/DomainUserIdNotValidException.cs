using System;

namespace Sev1.Accounts.Application.Exceptions.DomainUser
{
    public class DomainUserIdNotValidException : ApplicationException
    {
        public DomainUserIdNotValidException(string message) : base(message)
        {
        }
    }
}