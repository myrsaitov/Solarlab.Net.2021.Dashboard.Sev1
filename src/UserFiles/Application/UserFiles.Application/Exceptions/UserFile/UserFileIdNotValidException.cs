using System;

namespace Sev1.UserFiles.Application.Exceptions.UserFile
{
    public class UserFileIdNotValidException : ApplicationException
    {
        public UserFileIdNotValidException(string message) : base(message)
        {
        }
    }
}