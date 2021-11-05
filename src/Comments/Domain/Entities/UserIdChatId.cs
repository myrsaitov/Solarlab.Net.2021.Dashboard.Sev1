using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comments.Domain.Entities
{
    /// <summary>
    /// Сопоставление Id Пользлвателя(продавца) и Id чата
    /// </summary>
    public class UserIdChatId
    {
        /// <summary>
        /// Id Пользлвателя(продавца)
        /// </summary>
        [Key]
        public Guid UserId { get; set; }
        /// <summary>
        /// Id Чата
        /// </summary>
        public Guid ChatId { get; set; }
    }
}
