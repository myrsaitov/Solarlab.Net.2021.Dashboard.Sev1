using Comments.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Comments.Repository.Persistance
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly CommentDBContext _context;
        protected DbSet<TEntity> _dbSet { get; }

        public BaseRepository(CommentDBContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, 
            CancellationToken token)
        {
            return await _dbSet.CountAsync(predicate, token);
        }
        public async Task AddAsync(TEntity model, CancellationToken token)
        {
            await _dbSet.AddAsync(model, token);
            await SaveChangesAsync(token);
        }

        public async Task DeleteAsync(TEntity model, CancellationToken token)
        {
            _dbSet.Remove(model);
            await SaveChangesAsync(token);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate,
            CancellationToken token)
        {
            var result = await _dbSet.FirstOrDefaultAsync(predicate, token);

            if (result == null)
            {
                throw new NotFoundException(predicate.ToString());
            }
            return result;
        }

        public async Task<List<TEntity>> GetPagedAsync(Expression<Func<TEntity, bool>> predicate, int PageSize, int PageNumber, CancellationToken token)
        {
            var items = await _dbSet.Where(predicate).Skip(PageSize * PageNumber).Take(PageSize).ToListAsync(token);
            return items;
        }
        public async Task UpdateAsync(TEntity model, CancellationToken token)
        {
            _dbSet.Update(model);
            await SaveChangesAsync(token);
        }

        public async Task SaveChangesAsync(CancellationToken token)
        {
            await _context.SaveChangesAsync(token);
        }
    }
}
