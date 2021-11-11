using Comments.Contracts.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comments.Contracts.AdvertisementChat
{
    public class AdvertisementChatDtoRequestUpdateComment : BaseMessage
    {
        /// <summary>
        /// Id Комментария
        /// </summary>
        [Required]
        public Guid CommentId { get; set; }
    }
}