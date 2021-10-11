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
        /// 0 - Новое сообщение
        /// </summary>
        New,

        /// <summary>
        /// 1 - Попытка отправить сообщение
        /// </summary>
        Trying,

        /// <summary>
        /// 2 - Сообщение отправлено
        /// </summary>
        Sent,

        /// <summary>
        /// 3 - Произошла ошибка при отправки сообщения
        /// </summary>
        Failed
    }
}
