using Comments.Contracts.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Comments.Contracts
{
    public class CommentDtoRequestDelete
    {
        /// <summary>
        /// Id коментария
        /// </summary>
        [Required]
        public Guid Id { get; set; }
    }
}
