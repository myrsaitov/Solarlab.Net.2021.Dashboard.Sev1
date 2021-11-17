using AutoMapper;
using Comments.Contracts;
using Comments.Contracts.Enums;
using Comments.Domain.Entities;
using Comments.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Comments.Services
{
    /// <inheritdoc/>

    /// TODO: 
    ///     1. Проверить существует ли пользователь при добавлении/изменении/удалении комментария.
    ///     2. Проверить авторизирован ли пользователь

    public class CommentsService : ICommentsService
    // : ICommentsService
    {
        private readonly ICommentsRepository _repository;
        private readonly IMapper _mapper;

        public CommentsService(ICommentsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<List<SellerConsumerChatDtoResponceChatShort>> GetUserChatsPagedAsync(CommentDtoRequestGetUserChatsPaged dto, CancellationToken token)
        {
            Expression<Func<Chat, bool>> predicate = c => (c.SellerId == dto.UserId || c.ConsumerId == dto.UserId) && c.Type == ChatType.SellerConsumerChat;

            var pagesQuantity = await _repository.CountPagesChatsAsync(predicate, dto.PageSize, token);

            var chats = await _repository.GetUserChatsPages(dto.UserId, dto.PageSize, dto.PageNumber, pagesQuantity, token);

            await _repository.LoadLastMessageInChat(chats, token);

            //await LoadUserInfo(null, token);

            var dtoChatsShort = _mapper.Map<List<SellerConsumerChatDtoResponceChatShort>>(chats);

            return dtoChatsShort;
        }

        /// <inheritdoc/>
        public async Task<CommentDtoResponceChat> GetChatPagedAsync(CommentDtoRequestGetChatPaged dto, CancellationToken token)
        {
            Expression<Func<Chat, bool>> predicate;

            if (dto.Type == ChatType.AdvertisementChat)
            {
                predicate = c => c.AdvertisementId == dto.AdvertisementId && c.Type == dto.Type;
            }
            else if (dto.Type == ChatType.SellerConsumerChat)
            {
                predicate = c => c.AdvertisementId == dto.AdvertisementId && c.ConsumerId == dto.ConsumerId && c.Type == dto.Type;
            }
            else
            {
                throw new NotFoundException(dto.ToString());
            }
            var pagesQuantity = await _repository.CountPagesChatsAsync(predicate, dto.PageSize, token);

            var chat = await _repository.GetChatPagedAsync(predicate, dto.PageSize, dto.PageNumber, pagesQuantity, token);

            var dtoResponceChat = _mapper.Map<CommentDtoResponceChat>(chat);
            dtoResponceChat.TotalPages = pagesQuantity;
            dtoResponceChat.PageNumber = dto.PageNumber;
            dtoResponceChat.PageSize = dto.PageSize;

            return dtoResponceChat;
        }

        /// <inheritdoc/>
        public async Task DeleteChatAsync(CommentDtoRequestDeleteChat dto, CancellationToken token)
        {
            Expression<Func<Chat, bool>> predicate;

            if (dto.Type == ChatType.AdvertisementChat)
            {
                predicate = c => c.AdvertisementId == dto.AdvertisementId && c.Type == dto.Type;
            }
            else if (dto.Type == ChatType.SellerConsumerChat)
            {
                predicate = c => c.AdvertisementId == dto.AdvertisementId && c.ConsumerId == dto.ConsumerId && c.Type == dto.Type;
            }
            else
            {
                throw new NotFoundException(dto.ToString());
            }

            await _repository.RemoveChatAsync(predicate, token);
        }

        /// <inheritdoc/>
        public async Task<Guid> AddCommentAsync(CommentDtoRequestCreate dto, CancellationToken token)
        {
            var chatId = Guid.Empty;
            Expression<Func<Chat, bool>> predicate;

            if (dto.Type == ChatType.AdvertisementChat)
            {
                predicate = c => c.AdvertisementId == dto.AdvertisementId && c.Type == dto.Type;
            }
            else if (dto.Type == ChatType.SellerConsumerChat)
            {
                predicate = c => c.AdvertisementId == dto.AdvertisementId && c.ConsumerId == dto.ConsumerId && c.Type == dto.Type;
            }
            else
            {
                throw new NotFoundException(dto.ToString());
            }

            try
            {
                chatId = await _repository.GetChatId(predicate, token);
            }
            catch (NotFoundException e)
            {
                var chat = _mapper.Map<Chat>(dto);
                chatId = await _repository.AddChat(chat, token);
            }

            var comment = _mapper.Map<Comment>(dto);
            comment.ChatId = chatId;
            comment.IsUpdated = false;
            comment.CreationTime = DateTime.Now;
            comment.CommentStatus = CommentStatus.New;

            return await _repository.AddCommentAsync(comment, token);
        }

        /// <inheritdoc/>
        public async Task<Guid> UpdateCommentAsync(CommentDtoRequestUpdate dto, CancellationToken token)
        {
            var comment = await _repository.GetCommentAsync(dto.Id, token);
            comment.IsUpdated = true;
            comment.Message = dto.Message;

            return await _repository.UpdateCommentAsync(comment, token);
        }

        /// <inheritdoc/>
        public async Task DeleteCommentAsync(CommentDtoRequestDelete dto, CancellationToken token)
        {
            await _repository.DeleteCommentAsync(dto.Id, token);
        }

        /// <inheritdoc/>
        private async Task<Chat> LoadUserInfo(List<Guid> usersId, CancellationToken token)
        {
            throw new NotImplementedException();
            return null;
        }
    }
}
