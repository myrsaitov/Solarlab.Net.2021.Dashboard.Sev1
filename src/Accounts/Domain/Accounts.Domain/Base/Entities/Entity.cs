using System;

namespace Sev1.Accounts.Domain.Base.Entities
{
    /// <summary>
    /// Базовая сущность
    /// </summary>
    /// <typeparam name="TId">Класс идентификатора</typeparam>
    public abstract class Entity<TId>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public TId Id { get; set; }

        /// <summary>
        /// Время создания
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}