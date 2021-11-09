using System;

namespace Sev1.Accounts.Contracts.Exceptions.Base
{
    /// <summary>
    /// Базовое доменное исключение
    /// </summary>
    public class DomainException : ApplicationException
    {
        public DomainException(string message) : base(message)
        {
        }
    }
}