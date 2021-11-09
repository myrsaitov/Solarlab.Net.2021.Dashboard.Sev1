using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comments.Domain.Entities
{
    /// <summary>
    /// Оценка пользователя(продавца)
    /// </summary>
    public class UserRating
    {

        /// <summary>
        /// Id Пользователя
        /// </summary>
        [Key]
        public Guid UserId { get; set; }

        /// <summary>
        /// Общий рейтинг продавца
        /// </summary>
        public double RatingOverall { get; set; }

        /// <summary>
        /// Колличество голосов
        /// </summary>
        public int VoteCounter { get; set; }
    }
}
