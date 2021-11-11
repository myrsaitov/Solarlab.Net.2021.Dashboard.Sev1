using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comments.Contracts.AdvertisementChat
{
    public class AdvertisementChatDtoRequestDeleteComment
    {
        /// <summary>
        /// Id Сообщения
        /// </summary>
        [Required]
        public Guid CommentId { get; set; }
    }
}
