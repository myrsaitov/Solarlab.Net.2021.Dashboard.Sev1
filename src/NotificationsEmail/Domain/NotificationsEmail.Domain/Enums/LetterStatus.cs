using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationsEmail.Domain.Enums
{
    /// <summary>
    /// Статус отправки письма
    /// </summary>
    public enum LetterStatus
    {
        /// <summary>
        /// Сообщение отправлено
        /// </summary>
        Sent,

        /// <summary>
        /// Новое сообщение
        /// </summary>
        New,

        /// <summary>
        /// Попытка отправить сообщение
        /// </summary>
        Trying,

        /// <summary>
        /// Произошла ошибка при отправки сообщения
        /// </summary>
        Failed
    }
}
