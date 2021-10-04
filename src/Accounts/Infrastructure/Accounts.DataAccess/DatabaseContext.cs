using Sev1.Accounts.Domain;
using Sev1.Accounts.DataAccess.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Sev1.Accounts.Application.Contracts.Identity;

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

        public DbSet<User> DomainUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);

            SeedIdentity(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedIdentity(ModelBuilder modelBuilder)
        {
            var ADMIN_ROLE_ID = "d3300ca5-846f-4e6b-ac5f-1d3933115e67";
            var ADMIN_ID = "98b651ae-c9aa-4731-9996-57352d525f7e";
            var USER_ROLE_ID = "185230d2-58d8-4e29-aefd-a257fb82a150";

            modelBuilder.Entity<IdentityRole>(x =>
            {
                x.HasData(new[]
                {
                    new IdentityRole
                    {
                        Id = ADMIN_ROLE_ID,
                        Name = RoleConstants.AdminRole,
                        NormalizedName = "ADMIN"
                    },
                    new IdentityRole
                    {
                        Id = USER_ROLE_ID,
                        Name = RoleConstants.UserRole,
                        NormalizedName = "USER"
                    }
                });
            });

            var passwordHasher = new PasswordHasher<IdentityUser>();
            var adminUser = new IdentityUser
            {
                Id = ADMIN_ID,
                UserName = "admin",
                NormalizedUserName = "ADMIN"
            };
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "admin");

            modelBuilder.Entity<IdentityUser>(x =>
            {
                x.HasData(adminUser);
            });

            modelBuilder.Entity<IdentityUserRole<string>>(x =>
            {
                x.HasData(new IdentityUserRole<string>
                {
                    RoleId = ADMIN_ROLE_ID,
                    UserId = ADMIN_ID
                });
            });
        }
    }
}