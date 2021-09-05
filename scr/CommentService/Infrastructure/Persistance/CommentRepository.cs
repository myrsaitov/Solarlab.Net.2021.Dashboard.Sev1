using Domain;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistance
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
                throw new NotFoundException();
            }
            return result;
        }

        /// <inheritdoc/>
        public async Task<List<Comment>> GetAdvertismentCommentsAsync(Guid id)
        {
            List<Comment> list = await _dbSet.Where(c => c.AdvertesmentId == id).ToListAsync();
            return list;
        }

        /// <inheritdoc/> 
        public async Task AddCommentAsync(Comment comment)
        {
            _dbSet.Add(comment);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateCommentAsync(Comment comment)
        {
            _dbSet.Update(comment);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteCommentAsync(Guid id)
        {
            var comment = _dbSet.FirstOrDefault(c => c.Id == id); 
            if (comment == null)
            {
                throw new NotFoundException();
            }
            _dbSet.Remove(comment);
            await _context.SaveChangesAsync();
        }
    }
}