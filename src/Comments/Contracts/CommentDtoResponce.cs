using Comments.Contracts.Enums;
using Sev1.Accounts.Contracts.Contracts.User.Responses;
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
        /// Статус сообщения : Обычное, Новое
        /// </summary>
        public CommentStatus CommentStatus { get; set; }

        /// <summary>
        /// Сообщение отредактировано?
        /// </summary>
        public bool IsChanged { get; set; }

        /// <summary>
        /// Id объявления, к которому прикреплён коментарий
        /// </summary>
        public Guid ChatId { get; set; }

        /// <summary>
        /// Id автора сообщения
        /// </summary>
        public Guid AuthorId { get; set; }

        /// <summary>
        /// Автор
        /// </summary>
        public UserResponse Author { get; set; }
    }
}