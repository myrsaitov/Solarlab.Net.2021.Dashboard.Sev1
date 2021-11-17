using System;

namespace Sev1.Accounts.Domain.Base.Exceptions.Base
{
    /// <summary>
    /// Базовый абстрактный класс доменного исключения
    /// </summary>
    public abstract class DomainException : ApplicationException
    {
        public DomainException(string message) : base(message)
        {
        }
    }
}