using Comments.Contracts.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Comments.Contracts
{
    public class CommentDtoRequestCreate : DtoBase
    {
        /// <summary>
        /// Текст сообщения
        /// </summary>
        [Required]
        [MaxLength(255)]
        [MinLength(2)]
        public string Message { get; set; }

        /// <summary>
        /// Id автора
        /// </summary>
        [Required]
        public Guid AuthorId { get; set; }
    }
}
