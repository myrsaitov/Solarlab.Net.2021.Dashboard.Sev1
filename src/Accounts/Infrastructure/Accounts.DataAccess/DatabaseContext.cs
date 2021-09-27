using Sev1.Accounts.Domain;
using Sev1.Accounts.DataAccess.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;


namespace Sev1.Accounts.DataAccess
{
    /// <summary>
    /// Базовый контекст приложения.
    /// </summary>
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}