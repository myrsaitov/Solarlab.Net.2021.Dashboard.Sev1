using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comments.Contracts.Base
{
    public class BaseMessage
    {
        /// <summary>
        /// Текст сообщения
        /// </summary>
        [Required]
        [MaxLength(255)]
        [MinLength(2)]
        public string Message { get; set; }
    }
}
