using System;

namespace Sev1.UserFiles.Application.Exceptions.Advertisement
{
    public class CategoryCreateDtoNotValidException : ApplicationException
    {
        public CategoryCreateDtoNotValidException(string message) : base(message)
        {
        }
    }
}