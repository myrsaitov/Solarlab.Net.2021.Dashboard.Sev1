using System;

namespace Sev1.UserFiles.AppServices.Exceptions.UserFile
{
    public class GetPagedRequestNotValidException : ApplicationException
    {
        public GetPagedRequestNotValidException(string message) : base(message)
        {
        }
    }
}