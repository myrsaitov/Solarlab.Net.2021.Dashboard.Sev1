using Comments.Contracts.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Comments.Domain.Entities
{
    /// <summary>
    /// Сущьность коментария
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// Id коментария
        /// </summary>
        [Key]
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
        /// Статус сообщения
        /// </summary>
        public CommentStatus CommentStatus { get; set; }

        /// <summary>
        /// Сообщение отредактировано?
        /// </summary>
        public bool IsUpdated { get; set; }

        /// <summary>
        /// Id чата
        /// </summary>
        public Guid ChatId { get; set; }

        /// <summary>
        /// Id автора
        /// </summary>
        public Guid AuthorId { get; set; }
    }
}
