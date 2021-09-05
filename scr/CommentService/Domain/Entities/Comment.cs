using Contracts.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    /// <summary>
    /// Сущьность коментария
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        
        /// <summary>
        /// Текст сообщения
        /// </summary>
        public String Message { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// Статус сообщения
        /// </summary>
        public CommentStatus CommentStatus { get; set; }

        /// <summary>
        /// Id объявления, к которому прикреплён коментарий
        /// </summary>
        public Guid AdvertesmentId { get; set; }

        /// <summary>
        /// Id автора
        /// </summary>
        public Guid AuthorId { get; set; }
    }
}
