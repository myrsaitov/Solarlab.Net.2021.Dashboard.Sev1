using NotificationsEmail.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationsEmail.Services.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса нотификации
    /// </summary>
    public interface INotificationEmailService
    {
        /// <summary>
        /// Отправить email и сохранить его в базе данных
        /// </summary>
        /// <param name="letter"></param>
        /// <returns></returns>
        public Task SendEmailAsync(LetterDto letterDto);
    }
}
