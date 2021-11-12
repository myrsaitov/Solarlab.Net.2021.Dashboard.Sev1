using System;

namespace Sev1.Advertisements.Application.Exceptions.Category
{
    public class CategoryIdNotValidException : ApplicationException
    {
        public CategoryIdNotValidException(string message) : base(message)
        {
        }
    }
}