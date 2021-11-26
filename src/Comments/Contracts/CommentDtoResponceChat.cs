using Comments.Contracts.Base;
using System;
using System.Collections.Generic;

namespace Comments.Contracts
{
    public class CommentDtoResponceChat : DtoBase
    {
        /// <summary>
        /// Номер страницы
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Количество комментариев на странице
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Количество страниц
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Сообщения на странице
        /// </summary>
        public List<CommentDtoResponce> Messages { get; set; }
    }
}