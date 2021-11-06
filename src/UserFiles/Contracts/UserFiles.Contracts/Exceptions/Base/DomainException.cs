using System;

namespace Sev1.UserFiles.Contracts.Exceptions.Base
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