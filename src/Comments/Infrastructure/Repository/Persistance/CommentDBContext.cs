using Comments.Domain.Entities;
using Comments.Repository.Persistance.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Comments.Repository.Persistance
{
    /// <summary>
    /// Контекст БД коментариев
    /// </summary>
    public class CommentDBContext : DbContext
    {
        public DbSet<Comment> Comment_Table { get; set; }
        public DbSet<Chat> Chat_Table { get; set; }
        public CommentDBContext(DbContextOptions<CommentDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new ChatConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}