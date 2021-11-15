using System;

namespace Sev1.UserFiles.AppServices.Services.Advertisement.UserFile
{
    public class UserFileIdNotValidException : ApplicationException
    {
        public UserFileIdNotValidException(string message) : base(message)
        {
        }
    }
}