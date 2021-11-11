using System;
using System.Collections.Generic;

namespace Comments.Domain.Entities
{
    /// <summary>
    /// ChatBase - основные поля чата
    /// </summary>
    public class ChatBase
    {
        /// <summary>
        /// Создание пустого массива, при создании чата
        /// </summary>
        public ChatBase()
        {
            Messages = new List<Comment>();
        }

        /// <summary>
        /// Id Чата
        /// </summary>
        public Guid ChatId { get; set; }

        /// <summary>
        /// Список сообщений чата
        /// </summary>
        public List<Comment> Messages { get; set; }
    }
}
