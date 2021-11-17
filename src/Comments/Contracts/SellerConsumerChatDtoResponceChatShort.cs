using System;

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
