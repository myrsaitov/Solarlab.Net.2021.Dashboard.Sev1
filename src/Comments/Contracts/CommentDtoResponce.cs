using Comments.Contracts.Enums;
using System;

namespace Comments.Contracts
{
    public class CommentDtoResponce
    {
        /// <summary>
        /// Id Комментария
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string Message { get; set; }

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
        public Guid AuthorId { get; set; }
    }
}