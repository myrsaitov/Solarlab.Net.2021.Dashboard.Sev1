using System;

namespace Sev1.UserFiles.AppServices.Exceptions.UserFile
{
    public class UserFileIdNotValidException : ApplicationException
    {
        public UserFileIdNotValidException(string message) : base(message)
        {
        }
    }
}