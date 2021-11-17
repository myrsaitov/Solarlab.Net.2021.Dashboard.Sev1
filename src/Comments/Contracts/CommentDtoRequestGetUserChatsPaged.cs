using Comments.Contracts.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comments.Contracts
{
    public class CommentDtoRequestGetUserChatsPaged
    {

        /// <summary>
        /// Id пользователя
        /// </summary>
        [Required]
        public Guid UserId { get; set; }

        /// <summary>
        /// Номер страницы
        /// </summary>
        [Required]
        [GreaterThan(0)]
        public int PageNumber { get; set; }

        /// <summary>
        /// Количество комментариев на странице
        /// </summary>
        [Required]
        [GreaterThan(0)]
        public int PageSize { get; set; }
    }
}
