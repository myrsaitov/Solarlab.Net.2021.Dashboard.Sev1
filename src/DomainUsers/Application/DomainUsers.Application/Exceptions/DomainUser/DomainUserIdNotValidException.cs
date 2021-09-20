using System;

namespace Sev1.DomainUsers.Application.Exceptions.DomainUser
{
    public class DomainUserIdNotValidException : ApplicationException
    {
        public DomainUserIdNotValidException(string message) : base(message)
        {
        }
    }
}