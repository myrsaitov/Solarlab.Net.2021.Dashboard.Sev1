using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comments.Domain.Entities
{
    /// <summary>
    /// Сопоставление Id объявления и Id Потребителя(пользователя) к Id Чата
    /// </summary>
    public class AdvertisementIdConsumerIdChatId
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
        /// Id Чата
        /// </summary>
        public Guid ChatId { get; set; }
    }
}
