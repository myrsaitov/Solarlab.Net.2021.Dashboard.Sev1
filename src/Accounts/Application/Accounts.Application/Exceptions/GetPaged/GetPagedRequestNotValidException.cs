using System;

namespace Sev1.Advertisements.Application.Exceptions.Advertisement
{
    public class GetPagedRequestNotValidException : ApplicationException
    {
        public GetPagedRequestNotValidException(string message) : base(message)
        {
        }
    }
}