using Comments.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Comments.Services
{
    public interface ICommentsRepository
    {
        /// <summary>
        /// Создать чат
        /// </summary>
        /// <param name="chat"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<Guid> AddChat(Chat chat, CancellationToken token);

        /// <summary>
        /// Удалить чат
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task RemoveChatAsync(Expression<Func<Chat, bool>> predicate, CancellationToken token);
        
        /// <summary>
        /// Посчитать количество страниц чатов
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="pageSize"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<int> CountPagesChatsAsync(Expression<Func<Chat, bool>> predicate, int pageSize, CancellationToken token);

        /// <summary>
        /// Посчитать количество страниц сообщений
        /// </summary>
        /// <param name="chatId"></param>
        /// <param name="pageSize"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<int> CountPagesMessagesAsync(Guid chatId, int pageSize, CancellationToken token);

        /// <summary>
        /// Получить Id чата
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<Guid> GetChatId(Expression<Func<Chat, bool>> predicate, CancellationToken token);

        /// <summary>
        /// Получить чат, загрузить требуемую страницу с сообщениями
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pagesQuantity"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<Chat> GetChatPagedAsync(Expression<Func<Chat, bool>> predicate, int pageSize, int pageNumber, CancellationToken token);

        /// <summary>
        /// Получить требуемую страницу со списоком чатов пользователя 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pagesQuantity"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<List<Chat>> GetUserChatsPages(Expression<Func<Chat, bool>> predicate, int pageSize, int pageNumber, CancellationToken token);

        /// <summary>
        /// Загрузить последние сообщения в чаты
        /// </summary>
        /// <param name="chats"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<List<Chat>> LoadLastMessageInChat(List<Chat> chats, CancellationToken token);

        /// <summary>
        /// Добавить комментарий(сообщение)
        /// </summary>
        /// <param name="comment"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<Guid> AddCommentAsync(Comment comment, CancellationToken token);

        /// <summary>
        /// Удалить комментарий(сообщение)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task DeleteCommentAsync(Guid id, CancellationToken token);

        /// <summary>
        /// Обновить комментарий(сообщение)
        /// </summary>
        /// <param name="comment"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<Guid> UpdateCommentAsync(Comment comment, CancellationToken token);

        /// <summary>
        /// Зпгрузить комментарий(сообщение)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Comment> GetCommentAsync(Guid id, CancellationToken token);
    }
}