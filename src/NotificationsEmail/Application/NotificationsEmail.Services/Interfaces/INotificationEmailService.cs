using NotificationsEmail.Contracts;
using NotificationsEmail.Domain.Entities;
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
        /// <param name="letterDto"></param>
        /// <returns></returns>
        public Task SendNewEmailAsync(LetterDto letterDto);

        /// <summary>
        /// Отправить письмо, и обновить его статус в БД
        /// </summary>
        /// <param name="letter">Письмо</param>
        /// <returns></returns>
        public Task SendExistedEmailAndSaveResult(Letter letter);
    }
}
