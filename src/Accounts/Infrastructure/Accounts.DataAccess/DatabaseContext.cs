using Sev1.Accounts.Domain;
using Sev1.Accounts.DataAccess.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using IdentityUser = Sev1.Accounts.Application.Implementations.Identity.IdentityUser;
using Sev1.Accounts.Contracts.Enums;

namespace Sev1.Accounts.DataAccess
{
    /// <summary>
    /// Базовый контекст приложения.
    /// </summary>
    public class DatabaseContext : IdentityDbContext<IdentityUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<User> DomainUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            SeedIdentity(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedIdentity(ModelBuilder modelBuilder)
        {
            var ADMINISTRATOR_ROLE_ID = "cc836c4d-a3dd-4434-92f3-f45a9ed19dd3";
            var MODERATOR_ROLE_ID = "c373fe1b-9e38-498b-9729-6c719222b00d";
            var USER_ROLE_ID = "589a1f42-d43c-4315-8e02-432f64e02bc0";

            modelBuilder.Entity<IdentityRole>(x =>
            {
                x.HasData(new[]
                {
                    new IdentityRole
                    {
                        Id = ADMINISTRATOR_ROLE_ID,
                        Name = RoleConstants.Administrator.ToString(),
                        NormalizedName = "ADMINISTRATOR"
                    },
                    new IdentityRole
                    {
                        Id = MODERATOR_ROLE_ID,
                        Name = RoleConstants.Moderator.ToString(),
                        NormalizedName = "MODERATOR"
                    },
                    new IdentityRole
                    {
                        Id = USER_ROLE_ID,
                        Name = RoleConstants.User.ToString(),
                        NormalizedName = "USER"
                    }
                });
            });


            var passwordHasher = new PasswordHasher<IdentityUser>();

            var ADMINISTRATOR_ID = "757d5290-d036-4757-85ae-827b59e92cd3";
            var MODERATOR_ID = "a0d74199-2ad5-4d2f-a184-eb52f5bf9094";
            var USER_ID = "64dbb199-0a95-4f1a-afcf-10cc827fd3c8";

            // Administrator
            var adminUser = new IdentityUser
            {
                Id = ADMINISTRATOR_ID,
                UserName = "Administrator",
                NormalizedUserName = "ADMINISTRATOR",
                Email = "administrator@mail.ru",
                NormalizedEmail = "ADMINISTRATOR@MAIL.RU"
            };
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "administrator");

            modelBuilder.Entity<IdentityUser>(x =>
            {
                x.HasData(adminUser);
            });

            modelBuilder.Entity<IdentityUserRole<string>>(x =>
            {
                x.HasData(new IdentityUserRole<string>
                {
                    RoleId = ADMINISTRATOR_ROLE_ID,
                    UserId = ADMINISTRATOR_ID
                });
            });

            var adminDomainUser = new User
            {
                Id = ADMINISTRATOR_ID,
                UserName = "Administrator",
                FirstName = "Administrator",
                LastName = "Administrator",
                MiddleName = "Administrator",
            };

            modelBuilder.Entity<User>(x =>
            {
                x.HasData(adminDomainUser);
            });

            // Moderator
            var moderatorUser = new IdentityUser
            {
                Id = MODERATOR_ID,
                UserName = "Moderator",
                NormalizedUserName = "MODERATOR",
                Email = "moderator@mail.ru",
                NormalizedEmail = "MODERATOR@MAIL.RU"
            };
            moderatorUser.PasswordHash = passwordHasher.HashPassword(moderatorUser, "moderator");

            modelBuilder.Entity<IdentityUser>(x =>
            {
                x.HasData(moderatorUser);
            });

            modelBuilder.Entity<IdentityUserRole<string>>(x =>
            {
                x.HasData(new IdentityUserRole<string>
                {
                    RoleId = MODERATOR_ROLE_ID,
                    UserId = MODERATOR_ID
                });
            });

            var moderatorDomainUser = new User
            {
                Id = MODERATOR_ID,
                UserName = "Moderator",
                FirstName = "Moderator",
                LastName = "Moderator",
                MiddleName = "Moderator",
            };

            modelBuilder.Entity<User>(x =>
            {
                x.HasData(moderatorDomainUser);
            });

            // User
            var userUser = new IdentityUser
            {
                Id = USER_ID,
                UserName = "User",
                NormalizedUserName = "USER",
                Email = "user@mail.ru",
                NormalizedEmail = "USER@MAIL.RU"
            };
            userUser.PasswordHash = passwordHasher.HashPassword(moderatorUser, "user");

            modelBuilder.Entity<IdentityUser>(x =>
            {
                x.HasData(userUser);
            });

            modelBuilder.Entity<IdentityUserRole<string>>(x =>
            {
                x.HasData(new IdentityUserRole<string>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = USER_ID
                });
            });

            var userDomainUser = new User
            {
                Id = USER_ID,
                UserName = "User",
                FirstName = "User",
                LastName = "User",
                MiddleName = "User",
            };

            modelBuilder.Entity<User>(x =>
            {
                x.HasData(userDomainUser);
            });
        }
    }
}