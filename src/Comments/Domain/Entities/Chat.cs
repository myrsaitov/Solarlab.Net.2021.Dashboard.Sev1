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
        public Chat(Guid id)
        {
            ChatId = id;
            Messages = new List<Comment>();
        }

        /// <summary>
        /// Id Чата
        /// </summary>
        [Key]
        public Guid ChatId { get; set; }

        /// <summary>
        /// Список сообщений чата
        /// </summary>
        public List<Comment> Messages { get; set; }
    }
}
