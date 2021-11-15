using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comments.Contracts.Base
{
    public class DtoRequestDeleteCommentBase
    {
        /// <summary>
        /// Id Сообщения
        /// </summary>
        [Required]
        public Guid CommentId { get; set; }
    }
}
