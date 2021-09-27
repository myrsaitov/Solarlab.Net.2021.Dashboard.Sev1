using System;

namespace Sev1.Accounts.Application.Exceptions.Account
{
    public class GetPagedRequestNotValidException : ApplicationException
    {
        public GetPagedRequestNotValidException(string message) : base(message)
        {
        }
    }
}