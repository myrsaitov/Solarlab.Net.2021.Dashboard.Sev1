using System;

namespace Sev1.Accounts.Application.Exceptions.Advertisement
{
    public class CategoryIdNotValidException : ApplicationException
    {
        public CategoryIdNotValidException(string message) : base(message)
        {
        }
    }
}