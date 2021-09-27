using System.Collections.Generic;
using Sev1.Accounts.Domain.Base;

namespace Sev1.Accounts.Domain
{
    public class Advertisement : EntityMutable<int>
    {
        /// <summary>
        /// Заголовок объявления
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Текс объявления
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Id категории и ссылка на категорию
        /// </summary>
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        /// <summary>
        /// Коллекция связанных Tag
        /// </summary>
        public virtual ICollection<Tag> Tags { get; set; }
    }
}