using System;
using System.ComponentModel.DataAnnotations;

namespace Contracts
{
    public class CommentDtoRequestCreate : CommentDtoRequestBase
    {
        /// <summary>
        /// Id объявления, к которому прикреплён коментарий
        /// </summary>
        [Required]
        public Guid AdvertesmentId { get; set; }

        /// <summary>
        /// Id автора
        /// </summary>
        [Required]
        public Guid AuthorId { get; set; }
    }
}
