﻿namespace sev1.Advertisements.Domain.Shared.Exceptions
{
    public class ConflictException : DomainException
    {
        public ConflictException(string message) : base(message)
        {
        }
    }
}