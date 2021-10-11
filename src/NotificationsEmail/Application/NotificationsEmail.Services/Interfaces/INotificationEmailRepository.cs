using NotificationsEmail.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationsEmail.Services.Interfaces
{
    /// <summary>
    /// Интерфейс Репозитормя сервиса нотификации
    /// </summary>
    public interface INotificationEmailRepository
    {
        /// <summary>
        /// Добавить письмо в БД
        /// </summary>
        /// <param name="letter">Letter entity</param>
        /// <returns></returns>
        public Task<Guid> AddLetterAsync(Letter letter);

        /// <summary>
        /// Обновить письмо в БД 
        /// </summary>
        /// <param name="letter"></param>
        /// <returns></returns>        
        public Task<Guid> UpdateLetterAsync(Letter letter);

        /// <summary>
        /// Получить неотправленные письма за последние сутки
        /// (New и Trying)
        /// </summary>
        /// <returns></returns>
        public Task<List<Letter>> GetNotSendedLettersForLastDay();

    }
}
