using Comments.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Comments.Domain.Entities
{
    /// <summary>
    /// ChatBase - основные поля чата
    /// </summary>
    public class Chat
    {
        /// <summary>
        /// Создание пустого массива, при создании чата
        /// </summary>
        public Chat()
        {
            Messages = new List<Comment>();
        }

        /// <summary>
        /// Id Чата
        /// </summary>
        [Key]
        public Guid ChatId { get; set; }

        /// <summary>
        /// Тип чата
        /// </summary>
        public ChatType Type { get; set; }

        /// <summary>
        /// Id Объявления
        /// </summary>
        public Guid AdvertisementId { get; set; }

        /// <summary>
        /// Id Потребителя(пользователя)
        /// </summary>
        public Guid ConsumerId { get; set; }

        /// <summary>
        /// Id Продавца(пользователя)
        /// </summary>
        public Guid SellerId { get; set; }

        /// <summary>
        /// Список сообщений чата
        /// </summary>
        public List<Comment> Messages { get; set; }
    }
}
