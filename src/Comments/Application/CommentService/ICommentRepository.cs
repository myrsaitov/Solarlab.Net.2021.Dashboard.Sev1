using Comments.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Comments.Services
{
    public interface ICommentRepository
    {
        Task<Guid> AddAdvertisementIdChatId(AdvertisementIdChatId advertisementIdChatId, CancellationToken token);
        Task<Guid> AddAdvertisementIdConsumerIdChatId(AdvertisementIdConsumerIdChatId advertisementIdConsumerIdChatId, CancellationToken token);
        Task<Guid> AddChat(Chat chat, CancellationToken token);
        Task<Guid> AddCommentAsync(Comment comment, CancellationToken token);
        Task<int> CountPagesByChatIdAsync(Guid id, int PageSize, CancellationToken token);
        Task DeleteCommentAsync(Guid id, CancellationToken token);
        Task<Guid> GetChatId(AdvertisementIdChatId advertisementIdChatId, CancellationToken token);
        Task<Guid> GetChatId(AdvertisementIdConsumerIdChatId advertisementIdConsumerIdChatId, CancellationToken token);
        Task<Chat> GetChatPagedByChatIdAsync(Guid id, int PageSize, int PageNumber, CancellationToken token);
        Task RemoveChatAsync(Guid id, CancellationToken token);
        Task<Guid> UpdateCommentAsync(Comment comment, CancellationToken token);
    }
}