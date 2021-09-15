using System;
using System.Collections.Generic;
using Sev1.Advertisements.Contracts.Comments;
using Sev1.Advertisements.Contracts.Enums;

namespace Sev1.Advertisements.Contracts.Post
{
    public class PostDto : DtoBase
    {
        /// <summary>
        /// Заголовок объявления.
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Описание объявления.
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Наименование региона.
        /// </summary>
        public string RegionName { get; set; }
        
        /// <summary>
        /// Статус.
        /// </summary>
        public PostStatus PostStatusId { get; set; }
        
        /// <summary>
        /// Наименование статуcа.
        /// </summary>
        public string PostStatusName { get; set; }
        
        /// <summary>
        /// Идентификатор региона.
        /// </summary>
        public Guid RegionId { get; set; }
        
        public Guid CreatorId { get; set; }
        
        /// <summary>
        /// Коллекция комментариев.
        /// </summary>
        public List<CommentsDto> CommentsDto { get; set; }
    }
}