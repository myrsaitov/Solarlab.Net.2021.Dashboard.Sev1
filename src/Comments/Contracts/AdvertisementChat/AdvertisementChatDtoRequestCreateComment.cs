using Comments.Contracts.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Comments.Contracts.AdvertisementChat
{
    public class AdvertisementChatDtoRequestCreateComment : DtoRequestCreateCommentBase
    {
        /// <summary>
        /// Id объявления, к которому прикреплён коментарий
        /// </summary>
        [Required]
        public Guid AdvertisementId { get; set; }

        /// <summary>
        /// Id автора
        /// </summary>
        [Required]
        public Guid AuthorId { get; set; }
    }
}
