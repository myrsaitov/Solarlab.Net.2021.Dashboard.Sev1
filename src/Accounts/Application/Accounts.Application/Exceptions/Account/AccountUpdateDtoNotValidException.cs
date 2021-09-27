using System;

namespace Sev1.Accounts.Application.Exceptions.Account
{
    public class AccountUpdateDtoNotValidException : ApplicationException
    {
        public AccountUpdateDtoNotValidException(string message) : base(message)
        {
        }
    }
}