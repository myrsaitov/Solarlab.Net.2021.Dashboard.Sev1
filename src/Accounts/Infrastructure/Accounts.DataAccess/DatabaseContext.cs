using Sev1.Accounts.Domain;
using Sev1.Accounts.DataAccess.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
            var USER_ID_1 = "64dbb199-0a95-4f1a-afcf-10cc827fd3c8";
            var USER_ID_2 = "54b1ff98-6b5f-4c5e-97a9-747095e1f5dc";
            var USER_ID_3 = "c191e5f8-bf5b-40a9-9ab6-4d08704e373b";
            var USER_ID_4 = "09c529c8-e798-44ac-9eac-e0150182fa4c";
            var USER_ID_5 = "7e24ccd2-34fd-4289-9a78-1aae93623bae";

            // Administrator
            var adminUser = new IdentityUser
            {
                Id = ADMINISTRATOR_ID,
                UserName = "Administrator",
                NormalizedUserName = "ADMINISTRATOR",
                Email = "administrator@mail.ru",
                NormalizedEmail = "ADMINISTRATOR@MAIL.RU"
            };
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Zadm123!@#$%^()");

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
                PhoneNumber = "+79787713935",
                Address = "299011 г. Севастополь, ул. Чехова, 1",
                RegionId = 1
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
            moderatorUser.PasswordHash = passwordHasher.HashPassword(moderatorUser, "Zmod123!@#$%^()");

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
                PhoneNumber = "+79787713935",
                Address = "299011 г. Севастополь, ул. Гоголя, 1",
                RegionId = 1
            };

            modelBuilder.Entity<User>(x =>
            {
                x.HasData(moderatorDomainUser);
            });

            // User1
            var userUser = new IdentityUser
            {
                Id = USER_ID_1,
                UserName = "User1",
                NormalizedUserName = "USER1",
                Email = "user1@mail.ru",
                NormalizedEmail = "USER1@MAIL.RU"
            };
            userUser.PasswordHash = passwordHasher.HashPassword(userUser, "Zuse123!@#$%^()1");

            modelBuilder.Entity<IdentityUser>(x =>
            {
                x.HasData(userUser);
            });

            modelBuilder.Entity<IdentityUserRole<string>>(x =>
            {
                x.HasData(new IdentityUserRole<string>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = USER_ID_1
                });
            });

            var userDomainUser = new User
            {
                Id = USER_ID_1,
                UserName = "alex_1",
                FirstName = "Александр",
                LastName = "Викторович",
                MiddleName = "Булгаков",
                PhoneNumber = "+79787713931",
                Address = "299411 г. Москва, ул. Тургенева, 1",
                RegionId = 1
            };

            modelBuilder.Entity<User>(x =>
            {
                x.HasData(userDomainUser);
            });

            // User2
            userUser = new IdentityUser
            {
                Id = USER_ID_2,
                UserName = "User2",
                NormalizedUserName = "USER2",
                Email = "user2@mail.ru",
                NormalizedEmail = "USER2@MAIL.RU"
            };
            userUser.PasswordHash = passwordHasher.HashPassword(userUser, "Zuse123!@#$%^()2");

            modelBuilder.Entity<IdentityUser>(x =>
            {
                x.HasData(userUser);
            });

            modelBuilder.Entity<IdentityUserRole<string>>(x =>
            {
                x.HasData(new IdentityUserRole<string>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = USER_ID_2
                });
            });

            userDomainUser = new User
            {
                Id = USER_ID_2,
                UserName = "sidorov_2",
                FirstName = "Роман",
                LastName = "Сидоров",
                MiddleName = "Олегович",
                PhoneNumber = "+79787713932",
                Address = "299812 г. Судак, ул. Сергеева, 2",
                RegionId = 2
            };

            modelBuilder.Entity<User>(x =>
            {
                x.HasData(userDomainUser);
            });

            // User3
            userUser = new IdentityUser
            {
                Id = USER_ID_3,
                UserName = "User3",
                NormalizedUserName = "USER3",
                Email = "user3@mail.ru",
                NormalizedEmail = "USER3@MAIL.RU"
            };
            userUser.PasswordHash = passwordHasher.HashPassword(userUser, "Zuse123!@#$%^()3");

            modelBuilder.Entity<IdentityUser>(x =>
            {
                x.HasData(userUser);
            });

            modelBuilder.Entity<IdentityUserRole<string>>(x =>
            {
                x.HasData(new IdentityUserRole<string>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = USER_ID_3
                });
            });

            userDomainUser = new User
            {
                Id = USER_ID_3,
                UserName = "ivanov_3",
                FirstName = "Иван",
                LastName = "Иванов",
                MiddleName = "Иванович",
                PhoneNumber = "+79787713933",
                Address = "299713 г. Керчь, ул. Куприна, 3",
                RegionId = 3
            };

            modelBuilder.Entity<User>(x =>
            {
                x.HasData(userDomainUser);
            });

            // User4
            userUser = new IdentityUser
            {
                Id = USER_ID_4,
                UserName = "User4",
                NormalizedUserName = "USER4",
                Email = "user4@mail.ru",
                NormalizedEmail = "USER4@MAIL.RU"
            };
            userUser.PasswordHash = passwordHasher.HashPassword(userUser, "Zuse123!@#$%^()4");

            modelBuilder.Entity<IdentityUser>(x =>
            {
                x.HasData(userUser);
            });

            modelBuilder.Entity<IdentityUserRole<string>>(x =>
            {
                x.HasData(new IdentityUserRole<string>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = USER_ID_4
                });
            });

            userDomainUser = new User
            {
                Id = USER_ID_4,
                UserName = "vas_andr_4",
                FirstName = "Василий",
                LastName = "Максимов",
                MiddleName = "Андреевич",
                PhoneNumber = "+79485733234",
                Address = "299314 г. Симферополь, ул. Чернышевского, 4",
                RegionId = 4
            };

            modelBuilder.Entity<User>(x =>
            {
                x.HasData(userDomainUser);
            });

            // User5
            userUser = new IdentityUser
            {
                Id = USER_ID_5,
                UserName = "User5",
                NormalizedUserName = "USER5",
                Email = "user5@mail.ru",
                NormalizedEmail = "USER5@MAIL.RU"
            };
            userUser.PasswordHash = passwordHasher.HashPassword(userUser, "Zuse123!@#$%^()5");

            modelBuilder.Entity<IdentityUser>(x =>
            {
                x.HasData(userUser);
            });

            modelBuilder.Entity<IdentityUserRole<string>>(x =>
            {
                x.HasData(new IdentityUserRole<string>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = USER_ID_5
                });
            });

            userDomainUser = new User
            {
                Id = USER_ID_5,
                UserName = "petr_ivanov_5",
                FirstName = "Пётр",
                LastName = "Иванов",
                MiddleName = "Сергеевич",
                PhoneNumber = "+79687416935",
                Address = "299415 г. Ялта, ул. Достоевского, 5",
                RegionId = 5
            };

            modelBuilder.Entity<User>(x =>
            {
                x.HasData(userDomainUser);
            });
        }
    }
}