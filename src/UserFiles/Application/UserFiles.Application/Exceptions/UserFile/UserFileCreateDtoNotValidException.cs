using System;

namespace Sev1.UserFiles.Application.Exceptions.UserFile
{
    public class UserFileCreateDtoNotValidException : ApplicationException
    {
        public UserFileCreateDtoNotValidException(string message) : base(message)
        {
        }
    }
}