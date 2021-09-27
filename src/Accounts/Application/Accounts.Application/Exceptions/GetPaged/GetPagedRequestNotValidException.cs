using System;

namespace Sev1.Accounts.Application.Exceptions.Advertisement
{
    public class GetPagedRequestNotValidException : ApplicationException
    {
        public GetPagedRequestNotValidException(string message) : base(message)
        {
        }
    }
}