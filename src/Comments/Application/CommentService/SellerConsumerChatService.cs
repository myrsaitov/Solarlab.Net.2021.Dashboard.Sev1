using AutoMapper;
using Comments.Contracts;
using Comments.Contracts.SellerConsumerChat;
using Comments.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Comments.Services
{
    public class SellerConsumerChatService
    {
        private readonly IBaseRepository<AdvertisementIdConsumerIdChatId> _repository;
        private readonly IMapper _mapper;

        public SellerConsumerChatService(IBaseRepository<AdvertisementIdConsumerIdChatId> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<CommentDtoResponceChat> GetUserChatsAsync(SellerConsumerChatDtoRequestGetUserChats dto, CancellationToken token)
        {
            var Chats = await _repository.GetPagedAsync(a => a.ConsumerId == dto.UserId || a.SellerId == dto.UserId,
                                                        dto.PageSize,
                                                        dto.PageNumber,
                                                        token);
            Chats[1].
            return Chats;
        }

        /// <inheritdoc/>
        public async Task<CommentDtoResponceChat> GetPagedAsync(SellerConsumerChatDtoRequestGetPaged dto, CancellationToken token)
        {
            return null;
        }

        /// <inheritdoc/>
        public async Task DeleteChatAsync(SellerConsumerChatDtoRequestDeleteChat dto, CancellationToken token)
        {
        }


        public async Task<Guid> AddCommentAsync(SellerConsumerChatDtoRequestCreateComment dto, CancellationToken token)
        {
            return Guid.Empty;
        }

        /// <inheritdoc/>
        public async Task<Guid> UpdateCommentAsync(SellerConsumerChatDtoRequestUpdateComment dto, CancellationToken token)
        {
            return Guid.Empty;
        }

        /// <inheritdoc/>
        public async Task DeleteCommentAsync(SellerConsumerChatDtoRequestDeleteComment dto, CancellationToken token)
        {
        }
    }
}
