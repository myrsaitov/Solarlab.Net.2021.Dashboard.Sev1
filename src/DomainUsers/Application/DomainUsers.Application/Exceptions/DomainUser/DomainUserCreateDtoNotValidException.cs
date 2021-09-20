using System;

namespace Sev1.DomainUsers.Application.Exceptions.DomainUser
{
    public class DomainUserCreateDtoNotValidException : ApplicationException
    {
        public DomainUserCreateDtoNotValidException(string message) : base(message)
        {
        }
    }
}