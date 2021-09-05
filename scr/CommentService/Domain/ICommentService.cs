using Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// Сервис комментариев
    /// </summary>
    public interface ICommentService
    {
        /// <summary>
        /// Получить коментарий по его Id
        /// </summary>
        /// <param name="id">Id коментария</param>
        /// <returns></returns>
        public Task<CommentDtoResponce> GetCommentAsync(CommentDtoRequestGet dto);
        
        /// <summary>
        /// Получить все коментарии, прикреплённые к объявлению
        /// </summary>
        /// <param name="id">Id объявления</param>
        /// <returns></returns>
        public Task<List<CommentDtoResponce>> GetCommentsByAdvertismentIdAsync(Guid id);

        /// <summary>
        /// Создать коментарий
        /// </summary>
        /// <param name="comment">Коментарий</param>
        /// <returns></returns>
        public Task AddCommentAsync(CommentDtoRequestCreate dto);

        /// <summary>
        /// Изменить коментарий
        /// </summary>
        /// <param name="comment">Коментарий</param>
        /// <returns></returns>
        public Task UpdateCommentAsync(CommentDtoRequestUpdate dto);

        /// <summary>
        /// Удалить коментарий
        /// </summary>
        /// <param name="id">Id коментария</param>
        /// <returns></returns>
        public Task DeleteCommentAsync(CommentDtoRequestDelete dto);
    }
}
