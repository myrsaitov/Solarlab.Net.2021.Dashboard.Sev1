﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comments.Contracts.SellerConsumerChat
{
    public class SellerConsumerChatDtoRequestDeleteChat
    {
        /// <summary>
        /// Id объявления, к которому прикреплён коментарий
        /// </summary>
        [Required]
        public Guid AdvertisementId { get; set; }
    }
}
