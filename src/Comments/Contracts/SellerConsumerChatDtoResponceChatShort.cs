using Comments.Contracts.Base;
using System;

namespace Comments.Contracts
{
    public class SellerConsumerChatDtoResponceChatShort : DtoBase
    {
        /// <summary>
        /// Последнее сообщение
        /// </summary>
        public CommentDtoResponce LastMessage { get; set; }
    }
}
