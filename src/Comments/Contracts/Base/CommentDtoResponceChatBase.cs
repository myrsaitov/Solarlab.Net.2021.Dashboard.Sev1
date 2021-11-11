using Comments.Contracts.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comments.Contracts.Base
{
    public class CommentDtoResponceChatBase
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
