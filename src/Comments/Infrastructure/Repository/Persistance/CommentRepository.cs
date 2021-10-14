using Comments.Domain.Entities;
using Comments.Domain.Exceptions;
using Comments.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Comments.Repository.Persistance
{
    /// <inheritdoc/>
    public class CommentRepository : ICommentsRepository
    {
        private readonly CommentDBContext _context;
        private readonly DbSet<Comment> _dbSet;

        /// <inheritdoc/>
        public CommentRepository(CommentDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<Comment>();
        }

        /// <inheritdoc/>
        public async Task<Comment> GetCommentAsync(Guid id, CancellationToken token)
        {
            var result = await _dbSet.FirstOrDefaultAsync(c => c.Id == id, token);

            if (result == null)
            {
                throw new NotFoundException(id.ToString());
            }
            return result;
        }

        /// <inheritdoc/>
        public async Task<List<Comment>> GetCommentsByChatIdAsync(Guid id, int PageSize, int PageNumber, CancellationToken token)
        {
            var comments = await _dbSet.Where(c => c.ChatId == id).Skip(PageSize * PageNumber).Take(PageSize).OrderBy(c => c.CreationTime).ToListAsync(token);
            return comments;
        }

        /// <inheritdoc/>
        public async Task<int> GetTotalPagesByChatIdAsync(Guid id, int PageSize, CancellationToken token)
        {
            var totalComments = await _dbSet.CountAsync(c => c.ChatId == id, token);
            return (int) Math.Ceiling(totalComments / (double)PageSize);
        }

        /// <inheritdoc/>
        public async Task DeleteCommentsByChatIdAsync(Guid id, CancellationToken token)
        {

            var comments = _dbSet.Where(c => c.ChatId == id);
            _dbSet.RemoveRange(comments);
            await _context.SaveChangesAsync(token);
        }

        /// <inheritdoc/> 
        public async Task<Guid> AddCommentAsync(Comment comment, CancellationToken token)
        {
            await _dbSet.AddAsync(comment, token);
            await _context.SaveChangesAsync(token);
            return comment.Id;
        }

        /// <inheritdoc/>
        public async Task<Guid> UpdateCommentAsync(Comment comment, CancellationToken token)
        {
            _dbSet.Update(comment);
            await _context.SaveChangesAsync(token);
            return comment.Id;
        }

        /// <inheritdoc/>
        public async Task DeleteCommentAsync(Guid id, CancellationToken token)
        {
            var comment = await _dbSet.FirstOrDefaultAsync(c => c.Id == id, token);
            if (comment == null)
            {
                throw new NotFoundException(id.ToString());
            }
            _dbSet.Remove(comment);
            await _context.SaveChangesAsync();
        }
    }
}