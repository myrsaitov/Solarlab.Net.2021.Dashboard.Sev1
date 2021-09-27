using System;

namespace Sev1.Accounts.Contracts
{
    /// <summary>
    /// Базовый класс DTO.
    /// </summary>
    public class DtoBase
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }
    }
}