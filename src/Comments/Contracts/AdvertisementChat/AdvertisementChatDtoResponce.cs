using Comments.Contracts.Base;
using Comments.Contracts.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comments.Contracts.AdvertisementChat
{
    public class AdvertisementChatDtoResponce : CommentDtoResponceChatBase
    {
        /// <summary>
        /// Id объявления, к которому прикреплён коментарий
        /// </summary>
        public Guid AdvertisementId { get; set; }
    }
}
