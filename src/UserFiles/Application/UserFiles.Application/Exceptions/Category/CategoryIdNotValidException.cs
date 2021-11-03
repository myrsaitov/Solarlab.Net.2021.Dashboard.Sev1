using System;

namespace Sev1.UserFiles.Application.Exceptions.Advertisement
{
    public class CategoryIdNotValidException : ApplicationException
    {
        public CategoryIdNotValidException(string message) : base(message)
        {
        }
    }
}