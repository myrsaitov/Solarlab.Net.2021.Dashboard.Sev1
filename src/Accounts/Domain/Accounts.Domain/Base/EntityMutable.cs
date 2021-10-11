using System;

namespace Sev1.Accounts.Domain.Base
{
    /// <summary>
    /// Изменяемая сущность
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public class EntityMutable<TId> : Entity<TId>
    {
        /// <summary>
        /// Время изменения
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Маркёр удаленния сущности
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}