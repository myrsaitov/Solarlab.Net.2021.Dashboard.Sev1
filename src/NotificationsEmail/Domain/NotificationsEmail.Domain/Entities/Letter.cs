using NotificationsEmail.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace NotificationsEmail.Domain.Entities
{
    /// <summary>
    /// Сущьность письма
    /// </summary>
    public class Letter
    {
        /// <summary>
        /// Id письма
        /// </summary>
        [Key]
        public Guid LetterId { get; set; }

        /// <summary>
        /// Тема письма
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Текст
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Email получателя
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Время поступления запроса на отправку
        /// </summary>
        public DateTime SendRequesDate { get; set; }
        
        /// <summary>
        /// Статус письма
        /// </summary>
        public LetterStatus Status { get; set; }

        /// <summary>
        /// Текст ошибки отправки если есть
        /// </summary>
        public string ErrorMessage { get; set; }


    }
}
