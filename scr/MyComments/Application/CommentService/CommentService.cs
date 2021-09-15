using AutoMapper;
using Contracts;
using Contracts.Enums;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    /// <inheritdoc/>

    /// TODO: 
    ///     1. Проверить существует ли пользователь при добавлении/изменении/удалении комментария.
    ///     2. Проверить авторизирован ли пользователь

    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _repository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository repository, IMapper mapper)
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
        public async Task DeleteCommentsByChatIdAsync(Guid id)
        {
            await _repository.DeleteCommentsByChatIdAsync(id);
        }

        /// <inheritdoc/>
        public async Task<Guid> AddCommentAsync(CommentDtoRequestCreate dto)
        {
            var comment = _mapper.Map<Comment>(dto);
            comment.CreationTime = DateTime.Now;

            return await _repository.AddCommentAsync(comment);
        }

        /// <inheritdoc/>
        public async Task<Guid> UpdateCommentAsync(CommentDtoRequestUpdate dto)
        {
            var comment = await _repository.GetCommentAsync(dto.Id);
            comment.CommentStatus = CommentStatus.Changed;
            comment.Message = dto.Message;

            return await _repository.UpdateCommentAsync(comment);
        }

        /// <inheritdoc/>
        public async Task DeleteCommentAsync(CommentDtoRequestDelete dto)
        {
            await _repository.DeleteCommentAsync(dto.Id);
        }
    }
}
