using System;

namespace Sev1.Accounts.Application.Exceptions.Account
{
    public class AccountIdNotValidException : ApplicationException
    {
        public AccountIdNotValidException(string message) : base(message)
        {
        }
    }
}