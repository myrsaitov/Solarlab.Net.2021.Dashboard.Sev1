using Comments.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Comments.Services
{
    /// <summary>
    /// Интерфейс репозитория комментариев
    /// </summary>
    public interface ICommentsRepository
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
        public Task<List<Comment>> GetCommentsByChatIdAsync(Guid id, int PageSize, int PageNumber, CancellationToken token);

        /// <summary>
        /// Удалить все коментарии, прикреплённые к чату
        /// </summary>
        /// <param name="id">Id чата</param>
        public Task DeleteCommentsByChatIdAsync(Guid id);

        /// <summary>
        /// Создать коментарий
        /// </summary>
        /// <param name="comment">Коментарий</param>
        public Task<Guid> AddCommentAsync(Comment comment);

        /// <summary>
        /// Изменить коментарий
        /// </summary>
        /// <param name="comment">Коментарий</param>
        /// <returns></returns>
        public Task<Guid> UpdateCommentAsync(Comment comment);

        /// <summary>
        /// Удалить коментарий
        /// </summary>
        /// <param name="id">Id коментария</param>
        public Task DeleteCommentAsync(Guid id);
    }
}
