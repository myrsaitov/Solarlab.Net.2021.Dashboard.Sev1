using System;

namespace Sev1.UserFiles.Application.Exceptions.UserFile
{
    public class UserFileUpdateDtoNotValidException : ApplicationException
    {
        public UserFileUpdateDtoNotValidException(string message) : base(message)
        {
        }
    }
}