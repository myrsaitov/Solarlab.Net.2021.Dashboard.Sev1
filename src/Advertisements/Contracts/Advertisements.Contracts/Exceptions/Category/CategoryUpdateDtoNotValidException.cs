using System;

namespace Sev1.Advertisements.Contracts.Exceptions.Category
{
    public class CategoryUpdateDtoNotValidException : ApplicationException
    {
        public CategoryUpdateDtoNotValidException(string message) : base(message)
        {
        }
    }
}