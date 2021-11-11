using System;

namespace Sev1.Advertisements.Contracts.Exceptions.Category
{
    public class CategoryIdNotValidException : ApplicationException
    {
        public CategoryIdNotValidException(string message) : base(message)
        {
        }
    }
}