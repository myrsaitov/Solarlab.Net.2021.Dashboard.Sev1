using System;

namespace Sev1.UserFiles.AppServices.Services.Advertisement.UserFile
{
    public class UserFileGetPagedRequestNotValidException : ApplicationException
    {
        public UserFileGetPagedRequestNotValidException(string message) : base(message)
        {
        }
    }
}