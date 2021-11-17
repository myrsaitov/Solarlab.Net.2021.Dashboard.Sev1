using Comments.Contracts.Base;
using Comments.Contracts.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace Comments.Contracts
{
    public class CommentDtoRequestGetChatPaged : DtoBase
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
