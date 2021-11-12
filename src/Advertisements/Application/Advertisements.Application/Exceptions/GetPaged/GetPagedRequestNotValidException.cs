using System;

namespace Sev1.Advertisements.Application.Exceptions.GetPaged
{
    public class GetPagedRequestNotValidException : ApplicationException
    {
        public GetPagedRequestNotValidException(string message) : base(message)
        {
        }
    }
}