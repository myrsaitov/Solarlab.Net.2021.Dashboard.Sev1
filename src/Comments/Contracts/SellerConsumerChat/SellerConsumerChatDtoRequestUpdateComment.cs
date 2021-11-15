﻿using Comments.Contracts.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comments.Contracts.SellerConsumerChat
{
    public class SellerConsumerChatDtoRequestUpdateComment : DtoRequestUpdateCommentBase
    {
        /// <summary>
        /// Id Комментария
        /// </summary>
        [Required]
        public Guid CommentId { get; set; }
    }
}