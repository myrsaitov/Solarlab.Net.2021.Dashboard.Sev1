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
        public DbSet<AdvertisementIdChatId> AdvertisementIdChatId_Table { get; set; }
        public DbSet<AdvertisementIdConsumerIdChatId> AdvertisementIdConsumerIdChatId_Table { get; set; }
        public DbSet<Comment> Comment_Table { get; set; }
        public DbSet<CommentReview> CommentReview_Table { get; set; }
        public DbSet<UserIdChatId> UserIdChatId_Table { get; set; }
        public DbSet<UserRating> UserRating_Table { get; set; }
        public CommentDBContext(DbContextOptions<CommentDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdvertisementIdChatIdConfiguration());
            modelBuilder.ApplyConfiguration(new AdvertisementIdConsumerIdChatIdConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new CommentReviewConfiguration());
            modelBuilder.ApplyConfiguration(new UserIdChatIdConfiguration());
            modelBuilder.ApplyConfiguration(new UserRatingConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}