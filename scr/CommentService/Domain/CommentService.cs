using AutoMapper;
using Contracts;
using Contracts.Enums;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain
{

    /// <inheritdoc/>
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
        public async Task<CommentDtoResponce> GetCommentAsync(CommentDtoRequestGet dto)
        {
            var c = await _repository.GetCommentAsync(dto.Id);
            var commentDtoResponce = _mapper.Map<CommentDtoResponce>(c);
            return commentDtoResponce;


            // return _mapper.Map<CommentDtoResponce>(await _repository.GetCommentAsync(dto.Id));
        }

        /// <inheritdoc/>
        public async Task<List<CommentDtoResponce>> GetCommentsByAdvertismentIdAsync(Guid id)
        {
            return _mapper.Map<List<CommentDtoResponce>>(await _repository.GetAdvertismentCommentsAsync(id));
        }

        /// <inheritdoc/>
        public async Task AddCommentAsync(CommentDtoRequestCreate dto)
        {
            Comment comment = _mapper.Map<Comment>(dto);
            comment.CreationTime = DateTime.Now;
            await _repository.AddCommentAsync(comment);
        }

        /// <inheritdoc/>
        public async Task UpdateCommentAsync(CommentDtoRequestUpdate dto)
        {
            Comment comment = await _repository.GetCommentAsync(dto.Id);
            comment.CommentStatus = CommentStatus.Changed;
            comment.Message = dto.Message;
            await _repository.UpdateCommentAsync(comment);
        }

        /// <inheritdoc/>
        public async Task DeleteCommentAsync(CommentDtoRequestDelete dto)
        {
            await _repository.DeleteCommentAsync(dto.Id);
        }
    }
}
