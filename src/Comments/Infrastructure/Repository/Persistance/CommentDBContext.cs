using Comments.Repository.Persistance.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Comments.Repository.Persistance
{
    /// <summary>
    /// Контекст БД коментариев
    /// </summary>
    public class CommentDBContext : DbContext
    {
        public CommentDBContext(DbContextOptions<CommentDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
        }
    }
}