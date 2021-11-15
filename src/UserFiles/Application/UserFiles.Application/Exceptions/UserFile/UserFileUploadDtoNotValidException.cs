using System;

namespace Sev1.UserFiles.AppServices.Exceptions.UserFile
{
    public class UserFileUploadDtoNotValidException : ApplicationException
    {
        public UserFileUploadDtoNotValidException(string message) : base(message)
        {
        }
    }
}