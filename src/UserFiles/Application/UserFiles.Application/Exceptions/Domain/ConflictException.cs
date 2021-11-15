﻿using Sev1.UserFiles.AppServices.Exceptions.Domain.Base;

namespace Sev1.UserFiles.AppServices.Exceptions.Domain
{
    /// <summary>
    /// Доменное исключение при конфликте
    /// </summary>
    public class ConflictException : DomainException
    {
        public ConflictException(string message) : base(message)
        {
        }
    }
}