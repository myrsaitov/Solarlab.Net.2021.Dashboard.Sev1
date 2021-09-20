using System;

namespace Sev1.DomainUsers.Application.Exceptions.DomainUser
{
    public class DomainUserUpdateDtoNotValidException : ApplicationException
    {
        public DomainUserUpdateDtoNotValidException(string message) : base(message)
        {
        }
    }
}