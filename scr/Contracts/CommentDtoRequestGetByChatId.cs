using Contracts.Base;
using Contracts.ValidationAttributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Contracts
{
    public class CommentDtoRequestGetByChatId : BaseDto
    {
        /// <summary>
        /// Номер страницы
        /// </summary>
        [Required]
        [GreaterThan(-1)]
        public int PageNumber { get; set; }
        /// <summary>
        /// Количество комментариев на странице
        /// </summary>
        [Required]
        [GreaterThan(0)]
        public int PageSize { get; set; }
    }
}
