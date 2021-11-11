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
    /// Сопоставление Id объявления и Id чата
    /// </summary>
    public class AdvertisementIdChatId : ChatBase
    {
        /// <summary>
        /// Id Объявления
        /// </summary>
        [Key]
        public Guid AdvertisementId { get; set; }
    }
}
