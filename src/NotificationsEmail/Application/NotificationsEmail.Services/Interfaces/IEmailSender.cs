using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationsEmail.Services.Interfaces
{
    /// <summary>
    /// Интерфейс email нотификации
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        /// Отправить письмо
        /// </summary>
        /// <param name="email">email получателя</param>
        /// <param name="subject">Тема</param>
        /// <param name="body">сообщение</param>
        /// <returns></returns>
        public Task SendEmailAsync(string email, string subject, string body);
    }
}
