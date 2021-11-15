using AutoMapper;
using Comments.Contracts;
using Comments.Contracts.AdvertisementChat;
using Comments.Contracts.Base;
using Comments.Contracts.SellerConsumerChat;
using Comments.Domain.Entities;
using Comments.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Comments.Services
{
    /// <inheritdoc/>

    /// TODO: 
    ///     1. Проверить существует ли пользователь при добавлении/изменении/удалении комментария.
    ///     2. Проверить авторизирован ли пользователь

    public class CommentsService //: ICommentsService
    {
        private readonly ICommentRepository _repository;
        private readonly IMapper _mapper;

        public CommentsService(ICommentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<CommentDtoResponceChat> GetPagedAsync(DtoRequestGetPagedBase dto, CancellationToken token)
        {
            var chatId = await GetChatIdAsync(dto, token);

            var pages = await _repository.CountPagesByChatIdAsync(chatId, dto.PageSize, token);
            var pageNumber = dto.PageNumber > pages ? pages : dto.PageNumber;

            var chat = await _repository.GetChatPagedByChatIdAsync(chatId, dto.PageSize, pageNumber, token);

            var result = new CommentDtoResponceChat
            {
                AdvertisementId = dto.AdvertisementId,
                Messages = _mapper.Map<List<CommentDtoResponce>>(chat.Messages),
                PageSize = dto.PageSize,
                PageNumber = pageNumber,
                TotalPages = pages
            };

            return result;
        }

        private async Task<Guid> GetChatIdAsync(object dto, CancellationToken token)
        {
            if (dto is AdvertisementChatDtoRequestGetPaged ||
                dto is AdvertisementChatDtoRequestDeleteChat ||
                dto is AdvertisementChatDtoRequestCreateComment)
            {
                var advertisementIdChatId = _mapper.Map<AdvertisementIdChatId>(dto);

                return await _repository.GetChatId(advertisementIdChatId, token);
            }
            else if (dto is SellerConsumerChatDtoRequestGetPaged ||
                     dto is SellerConsumerChatDtoRequestDeleteChat ||
                     dto is SellerConsumerChatDtoRequestCreateComment)
            {
                var advertisementIdConsumerIdChatId = _mapper.Map<AdvertisementIdConsumerIdChatId>(dto);

                return await _repository.GetChatId(advertisementIdConsumerIdChatId, token);
            }

            throw new NotFoundException(dto.ToString());
        }

        /// <inheritdoc/>
        public async Task<CommentDtoResponceChat> GetUserChatsAsync(SellerConsumerChatDtoRequestGetUserChats dto, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task DeleteChatAsync(AdvertisementChatDtoRequestDeleteChat dto, CancellationToken token)
        {
            var chatId = await GetChatIdAsync(dto, token);
            await _repository.RemoveChatAsync(chatId, token);
        }

        /// <inheritdoc/>
        public async Task<Guid> AddCommentAsync(DtoRequestCreateCommentBase dto, CancellationToken token)
        {
            try
            {
                var chatId = await GetChatIdAsync(dto, token);
            }
            catch (NotFoundException e)
            {
                if (dto is AdvertisementChatDtoRequestCreateComment)
                {
                    await CreateChat((AdvertisementChatDtoRequestCreateComment)dto, token);

                }
                else if (dto is SellerConsumerChatDtoRequestCreateComment)
                {
                    await CreateChat((SellerConsumerChatDtoRequestCreateComment)dto, token);
                }
                else
                {
                    pass
                }

            }

            return null;
        }


        public async Task<Guid> AddCommentAsync(SellerConsumerChatDtoRequestCreateComment dto, CancellationToken token)
        {
            var advertisementIdConsumerIdChatId = _mapper.Map<AdvertisementIdConsumerIdChatId>(dto);
            var chatId = Guid.Empty;

            try
            {
                chatId = await _repository.GetChatId(advertisementIdConsumerIdChatId, token);
            }
            catch (NotFoundException e)
            {
                chatId = await CreateChat(dto, token);
            }

            var comment = _mapper.Map<Comment>(dto);
            comment.CreationTime = DateTime.Now;
            comment.ChatId = chatId;

            return await _repository.AddCommentAsync(comment, token);
        }

        private async Task<Guid> AddCommentAsync(Comment comment)
        {

        }

        private async Task<Guid> CreateChat(AdvertisementChatDtoRequestCreateComment dto, CancellationToken token)
        {
            var advertisementIdChatId = _mapper.Map<AdvertisementIdChatId>(dto);
            await _repository.AddAdvertisementIdChatId(advertisementIdChatId, token);

            return await _repository.AddChat(new Chat(advertisementIdChatId.ChatId), token);
        }

        private async Task<Guid> CreateChat(SellerConsumerChatDtoRequestCreateComment dto, CancellationToken token)
        {
            var advertisementIdConsumerIdChatId = _mapper.Map<AdvertisementIdConsumerIdChatId>(dto);
            await _repository.AddAdvertisementIdConsumerIdChatId(advertisementIdConsumerIdChatId, token);

            return await _repository.AddChat(new Chat(advertisementIdConsumerIdChatId.ChatId), token);            
        }

        /// <inheritdoc/>
        public async Task<Guid> UpdateCommentAsync(DtoRequestUpdateCommentBase dto, CancellationToken token)
        {
            return null;
        }

        /// <inheritdoc/>
        public async Task DeleteCommentAsync(DtoRequestDeleteCommentBase dto, CancellationToken token)
        {
        }

        /// <inheritdoc/>
        private async Task<Chat> LoadUserInfo(Chat chat, CancellationToken token)
        {
            return null;
        }
    }
}
