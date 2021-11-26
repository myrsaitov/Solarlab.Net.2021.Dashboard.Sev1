using Comments.Contracts.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Comments.Contracts
{
    public class CommentDtoRequestUpdate
    {
        /// <summary>
        /// Id коментария
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        [Required]
        [MaxLength(255)]
        [MinLength(2)]
        public string Message { get; set; }
    }
}