using System;
using System.ComponentModel.DataAnnotations;

namespace Comments.Contracts
{
    public class CommentDtoRequestBase
    {
        /// <summary>
        /// Текст сообщения
        /// </summary>
        [Required]
        [MaxLength (255)]
        [MinLength (2)]
        public String Message { get; set; }
    }
}
