using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comments.Contracts
{
    public class SellerConsumerChatDtoResponceChats
    {

        /// <summary>
        /// Количество страниц
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Номер страницы
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Количество чатов на странице
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Сообщения на странице
        /// </summary>
        public List<SellerConsumerChatDtoResponceChatShort> DtoChatsShort { get; set; }
    }
}
