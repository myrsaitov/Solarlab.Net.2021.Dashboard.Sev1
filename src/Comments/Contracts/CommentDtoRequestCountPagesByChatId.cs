using Comments.Contracts.Base;
using Comments.Contracts.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace Comments.Contracts
{
    public class CommentDtoRequestCountPagesByChatId : BaseDto
    {
        /// <summary>
        /// Количество комментариев на странице
        /// </summary>
        [Required]
        [GreaterThan(0)]
        public int PageSize { get; set; }
    }
}
