using Domain.Entities;
using Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Repository.Persistance
{
    /// <inheritdoc/>
    public class CommentRepository : ICommentRepository
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
        public async Task<Comment> GetCommentAsync(Guid id)
        {
            var result = await _dbSet.FirstOrDefaultAsync(c => c.Id == id);

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
        public async Task DeleteCommentsByChatIdAsync(Guid id)
        {

            var comments = _dbSet.Where(c => c.ChatId == id);
            _dbSet.RemoveRange(comments);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/> 
        public async Task<Guid> AddCommentAsync(Comment comment)
        {
            await _dbSet.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment.Id;
        }

        /// <inheritdoc/>
        public async Task<Guid> UpdateCommentAsync(Comment comment)
        {
            _dbSet.Update(comment);
            await _context.SaveChangesAsync();
            return comment.Id;
        }

        /// <inheritdoc/>
        public async Task DeleteCommentAsync(Guid id)
        {
            var comment = await _dbSet.FirstOrDefaultAsync(c => c.Id == id);
            if (comment == null)
            {
                throw new NotFoundException(id.ToString());
            }
            _dbSet.Remove(comment);
            await _context.SaveChangesAsync();
        }
    }
}