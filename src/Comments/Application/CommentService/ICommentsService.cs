using Comments.Contracts;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Comments.Services
{
    public interface ICommentsService
    {
        /// <summary>
        /// Загрузить чаты пользлвателя с последними сообщениями
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<SellerConsumerChatDtoResponceChats> GetUserChatsPagedAsync(CommentDtoRequestGetUserChatsPaged dto, CancellationToken token);

        /// <summary>
        /// Загрузить чат с определённой страницей комментариев(сообщений)
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<CommentDtoResponceChat> GetChatPagedAsync(CommentDtoRequestGetChatPaged dto, CancellationToken token);

        /// <summary>
        /// Получить последние комментарии, после токущего.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<List<CommentDtoResponce>> GetNextCommentsFromCurrent(CommentDtoRequestGetNextFromCurrent dto, CancellationToken token);

        /// <summary>
        /// Удалить чат
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task DeleteChatAsync(CommentDtoRequestDeleteChat dto, CancellationToken token);

        /// <summary>
        /// Добавить комментарий(сообщение) в чат.
        /// Если чата не существует - создать новый.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<Guid> AddCommentAsync(CommentDtoRequestCreate dto, CancellationToken token);

        /// <summary>
        /// Обновить комментарий(сообщение)
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<Guid> UpdateCommentAsync(CommentDtoRequestUpdate dto, CancellationToken token);

        /// <summary>
        /// Зпгрузить комментарий(сообщение)
        /// </summary>
        /// <param name="commentId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<CommentDtoResponce> GetCommentAsync(Guid commentId, CancellationToken token);

        /// <summary>
        /// Удалить комментарий(сообщение)
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task DeleteCommentAsync(CommentDtoRequestDelete dto, CancellationToken token);
    }
}