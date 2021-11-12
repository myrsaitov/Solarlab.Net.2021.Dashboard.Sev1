using System;

namespace Sev1.Advertisements.Application.Exceptions.Category
{
    public class CategoryCreateDtoNotValidException : ApplicationException
    {
        public CategoryCreateDtoNotValidException(string message) : base(message)
        {
        }
    }
}