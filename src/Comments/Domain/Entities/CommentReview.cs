using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comments.Domain.Entities
{
    public class CommentReview : Comment
    {
        /// <summary>
        /// Оценка, которую поставил пользователь продавцу
        /// </summary>
        public double Rating { get; set; }
    }
}
