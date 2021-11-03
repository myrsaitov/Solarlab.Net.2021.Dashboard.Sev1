using System;

namespace Sev1.UserFiles.Application.Exceptions.Advertisement
{
    public class GetPagedRequestNotValidException : ApplicationException
    {
        public GetPagedRequestNotValidException(string message) : base(message)
        {
        }
    }
}