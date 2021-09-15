using Contracts;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// Сервис комментариев
    /// </summary>
    public interface ICommentService
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
        public Task DeleteCommentsByChatIdAsync(Guid id);

        /// <summary>
        /// Создать коментарий
        /// </summary>
        /// <param name="comment">Коментарий</param>
        /// <returns></returns>
        public Task<Guid> AddCommentAsync(CommentDtoRequestCreate dto);

        /// <summary>
        /// Изменить коментарий
        /// </summary>
        /// <param name="comment">Коментарий</param>
        /// <returns></returns>
        public Task<Guid> UpdateCommentAsync(CommentDtoRequestUpdate dto);

        /// <summary>
        /// Удалить коментарий
        /// </summary>
        /// <param name="id">Id коментария</param>
        /// <returns></returns>
        public Task DeleteCommentAsync(CommentDtoRequestDelete dto);
    }
}
