using System;
using System.ComponentModel.DataAnnotations;

namespace Comments.Contracts
{
    public class CommentDtoRequestUpdate : CommentDtoRequestBase
    {
        /// <summary>
        /// Id коментария
        /// </summary>
        [Required]
        public Guid Id { get; set; }
    }
}