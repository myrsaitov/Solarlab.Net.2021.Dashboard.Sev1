using System.Collections.Generic;
using sev1.Advertisements.Contracts.Enums;
using Sev1.Advertisements.Domain.Base;

namespace Sev1.Advertisements.Domain
{
    public class Advertisement : EntityMutable<int>
    {
        /// <summary>
        /// Заголовок объявления
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Текст объявления
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Id категории
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Cсылка на категорию
        /// </summary>
        public virtual Category Category { get; set; }

        /// <summary>
        /// Коллекция связанных Tag
        /// </summary>
        public virtual ICollection<Tag> Tags { get; set; }

        /// <summary>
        /// Создатель объявления
        /// </summary>
        public string OwnerId { get; set; }

        /// <summary>
        /// Статус объявления
        /// </summary>
        public AdvertisementStatus Status { get; set; }
    }
}