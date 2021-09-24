using System;

namespace Sev1.Accounts.Application.Exceptions.DomainUser
{
    public class DomainUserUpdateDtoNotValidException : ApplicationException
    {
        public DomainUserUpdateDtoNotValidException(string message) : base(message)
        {
        }
    }
}