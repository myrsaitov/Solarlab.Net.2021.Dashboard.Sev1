using Comments.Contracts.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Comments.Contracts.AdvertisementChat
{
    public class AdvertisementChatDtoRequestDeleteChat : DtoRequestDeleteChatBase
    {
        /// <summary>
        /// Id объявления
        /// </summary>
        [Required]
        public Guid AdvertisementId { get; set; }
    }
}
