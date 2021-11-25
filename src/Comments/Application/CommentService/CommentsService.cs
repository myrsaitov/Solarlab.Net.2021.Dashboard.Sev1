using AutoMapper;
using Comments.Contracts;
using Comments.Contracts.Enums;
using Comments.Domain.Entities;
using Comments.Domain.Exceptions;
using sev1.Accounts.Contracts.UserProvider;
using Sev1.Accounts.Contracts.ApiClients.User;
using Sev1.Accounts.Contracts.Contracts.User.Responses;
using Sev1.Avdertisements.Contracts.ApiClients.AdvertisementValidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Comments.Services
{
    /// <inheritdoc/>

    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUserValidateApiClient _userApiClient;
        private readonly IAdvertisementValidateApiClient _advertisementValidateApiClient;
        private readonly IUserProvider _userProvider;

        public CommentsService(ICommentsRepository repository,
            IMapper mapper,
            IUserValidateApiClient userValidateApiClient,
            IAdvertisementValidateApiClient advertisementValidateApiClient,
            IUserProvider userProvider)
        {
            _repository = repository;
            _mapper = mapper;
            _userApiClient = userValidateApiClient;
            _advertisementValidateApiClient = advertisementValidateApiClient;
            _userProvider = userProvider;
        }

        /// <inheritdoc/>
        public async Task<SellerConsumerChatDtoResponceChats> GetUserChatsPagedAsync(CommentDtoRequestGetUserChatsPaged dto, CancellationToken token)
        {
            var userId = new Guid(_userProvider.GetUserId());
            Expression<Func<Chat, bool>> predicate = c => ((c.SellerId == userId || c.ConsumerId == userId) && c.Type == ChatType.SellerConsumerChat);
            var pagesQuantity = await _repository.CountPagesChatsAsync(predicate, dto.PageSize, token);

            var chats = await _repository.GetUserChatsPages(predicate, dto.PageSize, dto.PageNumber, token);

            await _repository.LoadLastMessageInChat(chats, token);


            Dictionary<string, UserResponse> usersInfoDict = new Dictionary<string, UserResponse>();

            foreach (var chat in chats)
            {
                AddUsersIdFromChatMassagesToDictionary(chat, usersInfoDict);
            }

            usersInfoDict = await LoadUserInfo(usersInfoDict);

            var dtoChatsShort = _mapper.Map<List<SellerConsumerChatDtoResponceChatShort>>(chats);


            foreach (var chat in dtoChatsShort)
            {
                chat.LastMessage.Author = usersInfoDict[chat.LastMessage.AuthorId.ToString()];
            }

            var sellerConsumerChatsDto = new SellerConsumerChatDtoResponceChats()
            {
                TotalPages = pagesQuantity,
                PageNumber = dto.PageNumber,
                PageSize = dto.PageSize,
                DtoChatsShort = dtoChatsShort
            };

            return sellerConsumerChatsDto;
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

            var chat = await _repository.GetChatPagedAsync(predicate, dto.PageSize, dto.PageNumber, token);


            Dictionary<string, UserResponse> usersInfoDict = new Dictionary<string, UserResponse>();

            AddUsersIdFromChatMassagesToDictionary(chat, usersInfoDict);

            usersInfoDict = await LoadUserInfo(usersInfoDict);

            var pagesQuantity = await _repository.CountPagesMessagesAsync(chat.ChatId, dto.PageSize, token);

            var dtoResponceChat = _mapper.Map<CommentDtoResponceChat>(chat);
            dtoResponceChat.TotalPages = pagesQuantity;
            dtoResponceChat.PageNumber = dto.PageNumber;
            dtoResponceChat.PageSize = dto.PageSize;

            foreach (var commentDto in dtoResponceChat.Messages)
            {
                commentDto.Author = usersInfoDict[commentDto.AuthorId.ToString()];
            }

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
            var advertisementDto = await _advertisementValidateApiClient.GetAdvertisementById(dto.AdvertisementId);

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
                if (chat.Type == ChatType.SellerConsumerChat)
                    chat.SellerId = new Guid(advertisementDto.OwnerId);

                chatId = await _repository.AddChat(chat, token);
            }

            var comment = new Comment
            {
                AuthorId = new Guid(_userProvider.GetUserId()),
                Message = dto.Message,
                ChatId = chatId,
                IsUpdated = false,
                CreationTime = DateTime.Now,
                CommentStatus = CommentStatus.New
            };

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
        public async Task<CommentDtoResponce> GetCommentAsync(Guid commentId, CancellationToken token)
        {
            var comment = _repository.GetCommentAsync(commentId, token);
            var commentDto = _mapper.Map<CommentDtoResponce>(comment);

            Dictionary<string, UserResponse> usersInfoDict = new Dictionary<string, UserResponse>();
            usersInfoDict.Add(commentDto.AuthorId.ToString(), null);
            usersInfoDict = await LoadUserInfo(usersInfoDict);
            commentDto.Author = usersInfoDict[commentDto.AuthorId.ToString()];

            return commentDto;
        }

        /// <inheritdoc/>
        private async Task<Dictionary<string, UserResponse>> LoadUserInfo(Dictionary<string, UserResponse> userDict)
        {
            userDict = await _userApiClient.GetUsersByListId(userDict.Keys.ToList());
            return userDict;
        }

        /// <inheritdoc/>
        public async Task<List<CommentDtoResponce>> GetNextCommentsFromCurrent(CommentDtoRequestGetNextFromCurrent dto, CancellationToken token)
        {
            var comments = await _repository.GetNextCommentsFromCurrent(dto.ChatId, dto.CommentId, dto.Quantity, token);

            Dictionary<string, UserResponse> usersInfoDict = new Dictionary<string, UserResponse>();
            foreach (Comment comment in comments)
            {
                var userId = comment.AuthorId.ToString();
                if (!usersInfoDict.ContainsKey(userId))
                    usersInfoDict.Add(userId, null);
            }
            usersInfoDict = await LoadUserInfo(usersInfoDict);
            var commentsDto = _mapper.Map<List<CommentDtoResponce>>(comments);
            foreach (var commentDto in commentsDto)
            {
                commentDto.Author = usersInfoDict[commentDto.AuthorId.ToString()];
            }

            return commentsDto;
        }

        /// <inheritdoc/>
        private Dictionary<string, UserResponse> AddUsersIdFromChatMassagesToDictionary(Chat chat, Dictionary<string, UserResponse> usersInfoDictionary)
        {
            foreach (Comment comment in chat.Messages)
            {
                var userId = comment.AuthorId.ToString();
                if (!usersInfoDictionary.ContainsKey(userId))
                    usersInfoDictionary.Add(userId, null);
            }

            return usersInfoDictionary;
        }
    }
}
