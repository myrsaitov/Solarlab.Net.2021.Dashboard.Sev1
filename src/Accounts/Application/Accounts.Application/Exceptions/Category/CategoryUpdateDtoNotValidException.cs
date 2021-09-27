using System;

namespace Sev1.Accounts.Application.Exceptions.Account
{
    public class CategoryUpdateDtoNotValidException : ApplicationException
    {
        public CategoryUpdateDtoNotValidException(string message) : base(message)
        {
        }
    }
}