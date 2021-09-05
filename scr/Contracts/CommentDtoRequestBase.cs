using System;
using System.ComponentModel.DataAnnotations;

namespace Contracts
{
    public class CommentDtoRequestBase
    {
        /// <summary>
        /// Текст сообщения
        /// </summary>
        [Required]
        [MaxLength (255)]
        [MinLength (3)]
        public String Message { get; set; }
    }
}
