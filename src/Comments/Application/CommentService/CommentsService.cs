using AutoMapper;
using Comments.Contracts;
using Comments.Contracts.Enums;
using Comments.Domain.Entities;
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

    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository _repository;
        private readonly IMapper _mapper;

        public CommentsService(ICommentsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<List<CommentDtoResponce>> GetCommentsByChatIdAsync(CommentDtoRequestGetByChatId dto, CancellationToken token)
        {
            var comments = await _repository.GetCommentsByChatIdAsync(dto.Id, dto.PageSize, dto.PageNumber, token);
            return _mapper.Map<List<CommentDtoResponce>>(comments);
        }

        /// <inheritdoc/>
        public async Task<int> CountPagesAsync(Guid id, int pageSize, CancellationToken token)
        {
            return await _repository.GetTotalPagesByChatIdAsync(id, pageSize, token);
        }

        /// <inheritdoc/>
        public async Task DeleteCommentsByChatIdAsync(Guid id, CancellationToken token)
        {
            await _repository.DeleteCommentsByChatIdAsync(id, token);
        }

        /// <inheritdoc/>
        public async Task<Guid> AddCommentAsync(CommentDtoRequestCreate dto, CancellationToken token)
        {
            var comment = _mapper.Map<Comment>(dto);
            comment.CreationTime = DateTime.Now;

            return await _repository.AddCommentAsync(comment, token);
        }

        /// <inheritdoc/>
        public async Task<Guid> UpdateCommentAsync(CommentDtoRequestUpdate dto, CancellationToken token)
        {
            var comment = await _repository.GetCommentAsync(dto.Id, token);
            comment.CommentStatus = CommentStatus.Changed;
            comment.Message = dto.Message;

            return await _repository.UpdateCommentAsync(comment, token);
        }

        /// <inheritdoc/>
        public async Task DeleteCommentAsync(CommentDtoRequestDelete dto, CancellationToken token)
        {
            await _repository.DeleteCommentAsync(dto.Id, token);
        }
    }
}
