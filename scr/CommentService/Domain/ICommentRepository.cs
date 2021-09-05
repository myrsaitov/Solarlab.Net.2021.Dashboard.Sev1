using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// Интерфейс репозитория комментариев
    /// </summary>
    public interface ICommentRepository
    {
        /// <summary>
        /// Получить комментарий по его Id
        /// </summary>
        /// <param name="id">Id коментария</param>
        /// <returns></returns>
        public Task<Comment> GetCommentAsync(Guid id);
        
        /// <summary>
        /// Получить все коментарии, прикреплённые к объявлению
        /// </summary>
        /// <param name="id">Id объявления</param>
        /// <returns></returns>
        public Task<List<Comment>> GetAdvertismentCommentsAsync(Guid id);

        /// <summary>
        /// Создать коментарий
        /// </summary>
        /// <param name="comment">Коментарий</param>
        public Task AddCommentAsync(Comment comment);

        /// <summary>
        /// Изменить коментарий
        /// </summary>
        /// <param name="comment">Коментарий</param>
        /// <returns></returns>
        public Task UpdateCommentAsync(Comment comment);

        /// <summary>
        /// Удалить коментарий
        /// </summary>
        /// <param name="id">Id коментария</param>
        public Task DeleteCommentAsync(Guid id);
    }
}
