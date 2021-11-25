using Comments.Contracts.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comments.Contracts
{
    public class CommentDtoRequestGetNextFromCurrent
    {
        /// <summary>
        /// Id Комментария
        /// </summary>
        public Guid CommentId { get; set; }

        /// <summary>
        /// Id объявления, к которому прикреплён коментарий
        /// </summary>
        [Required]
        public Guid ChatId { get; set; }

        /// <summary>
        /// Колличество комментариев
        /// </summary>
        [Required]
        [GreaterThan(0)]
        public int Quantity { get; set; }
    }
}
