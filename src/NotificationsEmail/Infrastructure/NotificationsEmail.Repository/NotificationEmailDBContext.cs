using Microsoft.EntityFrameworkCore;
using NotificationsEmail.Repository.Configuration;

namespace NotificationsEmail.Repository
{
    /// <summary>
    /// Контекст БД сервиса нотификации
    /// </summary>
    public class NotificationEmailDBContext : DbContext
    {
        public NotificationEmailDBContext(DbContextOptions<NotificationEmailDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NotificationEmailDBConfiguration());
        }
    }
}