using System;

namespace Sev1.Advertisements.Contracts.Exceptions.GetPaged
{
    public class GetPagedRequestNotValidException : ApplicationException
    {
        public GetPagedRequestNotValidException(string message) : base(message)
        {
        }
    }
}