﻿using System;

namespace Sev1.Accounts.Application.Exceptions.Account
{
    public class CategoryCreateDtoNotValidException : ApplicationException
    {
        public CategoryCreateDtoNotValidException(string message) : base(message)
        {
        }
    }
}