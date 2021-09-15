using Contracts.Base;
using Contracts.Enums;
using System;

namespace Contracts
{
    public class CommentDtoResponce : BaseDto
    {
        /// <summary>
        /// Текст сообщения
        /// </summary>
        public String Message { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// Статус сообщения : Обычное, Изменённое, Новое
        /// </summary>
        public CommentStatus CommentStatus { get; set; }

        /// <summary>
        /// Id объявления, к которому прикреплён коментарий
        /// </summary>
        public Guid ChatId { get; set; }

        /// <summary>
        /// Id автора
        /// </summary>
        public String AuthorName { get; set; }
    }
}