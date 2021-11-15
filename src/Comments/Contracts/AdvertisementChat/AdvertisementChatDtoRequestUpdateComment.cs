using Comments.Contracts.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Comments.Contracts.AdvertisementChat
{
    public class AdvertisementChatDtoRequestUpdateComment : DtoRequestUpdateCommentBase
    {
        /// <summary>
        /// Id Комментария
        /// </summary>
        [Required]
        public Guid CommentId { get; set; }
    }
}