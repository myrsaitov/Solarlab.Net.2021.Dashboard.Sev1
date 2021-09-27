using System.Collections.Generic;
using Sev1.Accounts.Domain.Base;

namespace Sev1.Accounts.Domain
{
    public class Account : EntityMutable<int>
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
    }
}