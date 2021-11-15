using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comments.Contracts
{
    public class SellerConsumerChatDtoResponceChatShort
    {
        /// <summary>
        /// Id объявления
        /// </summary>
        public Guid AdvertisementId { get; set; }

        /// <summary>
        /// Последнее сообщение
        /// </summary>
        public CommentDtoResponce LastMessage { get; set; }
    }
}
