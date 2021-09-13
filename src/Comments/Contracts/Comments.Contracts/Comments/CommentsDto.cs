using System;

namespace Advertisements.Contracts.Comments
{
    /// <summary>
    /// Модель представления комментариев к объявлению.
    /// </summary>
    public class CommentsDto : DtoBase
    {
        /// <summary>
        /// Идентификатор объявления.
        /// </summary>
        public Guid PostId { get; set; }
        
        /// <summary>
        /// Тело комментария.
        /// </summary>
        public string CommentBody { get; set; }
        
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string UserName { get; set; }
    }
}