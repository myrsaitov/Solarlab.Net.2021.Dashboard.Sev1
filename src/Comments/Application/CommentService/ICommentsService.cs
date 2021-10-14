using Comments.Contracts;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Comments.Services
{
    /// <summary>
    /// Сервис комментариев
    /// </summary>
    public interface ICommentsService
    {
        
        /// <summary>
        /// Получить все коментарии, прикреплённые к объявлению
        /// </summary>
        /// <param name="id">Id чата</param>
        /// <returns></returns>
        public Task<List<CommentDtoResponce>> GetCommentsByChatIdAsync(CommentDtoRequestGetByChatId dto, CancellationToken token);

        /// <summary>
        /// Удалить все коментарии, прикреплённые к чату
        /// </summary>
        /// <param name="id">Id чата</param>
        /// <returns></returns>
        public Task DeleteCommentsByChatIdAsync(Guid id, CancellationToken token);

        /// <summary>
        /// Посчитать количество страниц комментариев в чате
        /// </summary>
        /// <param name="id">Id чата</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <param name="token">CancellationToken</param>
        /// <returns></returns>
        public Task<int> CountPagesAsync(Guid id, int pageSize, CancellationToken token);

        /// <summary>
        /// Создать коментарий
        /// </summary>
        /// <param name="comment">Коментарий</param>
        /// <returns></returns>
        public Task<Guid> AddCommentAsync(CommentDtoRequestCreate dto, CancellationToken token);

        /// <summary>
        /// Изменить коментарий
        /// </summary>
        /// <param name="comment">Коментарий</param>
        /// <returns></returns>
        public Task<Guid> UpdateCommentAsync(CommentDtoRequestUpdate dto, CancellationToken token);

        /// <summary>
        /// Удалить коментарий
        /// </summary>
        /// <param name="id">Id коментария</param>
        /// <returns></returns>
        public Task DeleteCommentAsync(CommentDtoRequestDelete dto, CancellationToken token);
    }
}
