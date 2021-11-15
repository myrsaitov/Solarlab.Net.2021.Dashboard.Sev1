using Comments.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comments.Domain.Entities
{
    /// <summary>
    /// Чат между продавцом и покупателем
    /// Сопоставление Id объявления и Id Потребителя(пользователя) к Чату
    /// </summary>
    public class AdvertisementIdConsumerIdChatId : ChatIdBase
    {
        /// <summary>
        /// Id Объявления
        /// </summary>
        [Key]
        public Guid AdvertisementId { get; set; }

        /// <summary>
        /// Id Потребителя(пользователя)
        /// </summary>
        [Key]
        public Guid ConsumerId { get; set; }

        /// <summary>
        /// Id Продавца(пользователя)
        /// </summary>
        public Guid SellerId { get; set; }
    }
}
