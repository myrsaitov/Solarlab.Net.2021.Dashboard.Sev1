using System;

namespace Sev1.Accounts.Domain.Base.Entities
{
    /// <summary>
    /// Изменяемая сущность (хранит информацию об изменениях)
    /// </summary>
    /// <typeparam name="TId">Класс идентификатора</typeparam>
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