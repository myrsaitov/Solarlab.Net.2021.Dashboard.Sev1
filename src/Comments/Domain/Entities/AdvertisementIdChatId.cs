using Comments.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comments.Domain.Entities
{
    /// <summary>
    /// Комментарии к объявлению
    /// Сопоставление Id объявления к Чату
    /// </summary>
    public class AdvertisementIdChatId : ChatIdBase
    {
        /// <summary>
        /// Id Объявления
        /// </summary>
        [Key]
        public Guid AdvertisementId { get; set; }
    }
}
