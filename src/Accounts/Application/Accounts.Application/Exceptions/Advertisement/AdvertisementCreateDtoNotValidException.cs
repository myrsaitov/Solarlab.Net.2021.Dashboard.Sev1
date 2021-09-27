using System;

namespace Sev1.Accounts.Application.Exceptions.Account
{
    public class AccountCreateDtoNotValidException : ApplicationException
    {
        public AccountCreateDtoNotValidException(string message) : base(message)
        {
        }
    }
}