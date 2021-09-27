﻿using Sev1.Accounts.Domain.Exceptions;

namespace Sev1.Accounts.Application.Exceptions.Identity
{
    public class IdentityUserNotFoundException : NotFoundException
    {
        public IdentityUserNotFoundException(string message) : base(message)
        {
        }
    }
}
