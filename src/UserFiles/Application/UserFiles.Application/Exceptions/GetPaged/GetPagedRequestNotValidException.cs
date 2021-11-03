using System;

namespace Sev1.UserFiles.Application.Exceptions.UserFile
{
    public class GetPagedRequestNotValidException : ApplicationException
    {
        public GetPagedRequestNotValidException(string message) : base(message)
        {
        }
    }
}