using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounts.DataAccess.Migrations
{
    public partial class UserWereAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DomainUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteAdvertisement",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AdvertisementId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteAdvertisement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserUser",
                columns: table => new
                {
                    FriendUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IgnoredUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUser", x => new { x.FriendUsersId, x.IgnoredUsersId });
                    table.ForeignKey(
                        name: "FK_UserUser_DomainUsers_FriendUsersId",
                        column: x => x.FriendUsersId,
                        principalTable: "DomainUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserUser_DomainUsers_IgnoredUsersId",
                        column: x => x.IgnoredUsersId,
                        principalTable: "DomainUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteAdvertisementUser",
                columns: table => new
                {
                    FavoriteAdvertisementsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteAdvertisementUser", x => new { x.FavoriteAdvertisementsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_FavoriteAdvertisementUser_DomainUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "DomainUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteAdvertisementUser_FavoriteAdvertisement_FavoriteAdvertisementsId",
                        column: x => x.FavoriteAdvertisementsId,
                        principalTable: "FavoriteAdvertisement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cc836c4d-a3dd-4434-92f3-f45a9ed19dd3", "4014a1c4-4901-445c-b860-414c501e8d9b", "Administrator", "ADMINISTRATOR" },
                    { "c373fe1b-9e38-498b-9729-6c719222b00d", "70f55f5f-8976-4823-a60d-ae6c6c048c02", "Moderator", "MODERATOR" },
                    { "589a1f42-d43c-4315-8e02-432f64e02bc0", "61dc20cb-d0fc-403f-a65e-622295a85625", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7e24ccd2-34fd-4289-9a78-1aae93623bae", 0, "ca065898-16ca-4791-9d4c-f62522d6daa1", "user5@mail.ru", false, false, null, "USER5@MAIL.RU", "USER5", "AQAAAAEAACcQAAAAELUd9ojI1GopRsMcx31pPt1iRAoH6Q9Nx2XN+T4oxy93bBgFGWETaOzm7swldITDbg==", null, false, "a5b7d888-ec13-4914-961e-bce7af54ab6f", false, "User5" },
                    { "c191e5f8-bf5b-40a9-9ab6-4d08704e373b", 0, "4a3a245d-8f59-41b3-beb9-c5dfd642a302", "user3@mail.ru", false, false, null, "USER3@MAIL.RU", "USER3", "AQAAAAEAACcQAAAAEDyKwykgNQDr5ejmewG5yDl6rdW8NjVDg3gKHKrcVr60cIboKuahFbrFHTMqC/ixgw==", null, false, "6b4030ef-c247-4672-95a3-584de8798d7a", false, "User3" },
                    { "54b1ff98-6b5f-4c5e-97a9-747095e1f5dc", 0, "ca86a7b8-b85c-4212-998f-bf729c6a7263", "user2@mail.ru", false, false, null, "USER2@MAIL.RU", "USER2", "AQAAAAEAACcQAAAAEOx8wlRm2FWTbPl4ojk+jmk8hnKwpXdH/H121gL/HLgqfIn9Ui6nHF2Ksf4BvER7Wg==", null, false, "024fac35-0f6e-4bae-867c-f19e6924b548", false, "User2" },
                    { "09c529c8-e798-44ac-9eac-e0150182fa4c", 0, "2fa79519-2b1e-4e63-9263-eaa4c9acd881", "user4@mail.ru", false, false, null, "USER4@MAIL.RU", "USER4", "AQAAAAEAACcQAAAAEBc1NdNDZkdfFB8GWZ69GtkaEdoqzlY8E/oX8IIo/wvLGCnwJ5KlPnMrtKnjUcMCmQ==", null, false, "bda7ff2f-85a8-4e55-a9ec-dfb0a5f4993f", false, "User4" },
                    { "a0d74199-2ad5-4d2f-a184-eb52f5bf9094", 0, "a5296d0d-d103-400f-a1d0-31dcbeb35bc1", "moderator@mail.ru", false, false, null, "MODERATOR@MAIL.RU", "MODERATOR", "AQAAAAEAACcQAAAAENn6A7JFFAccNitm3k6SKLjufOExPZL10xUThp0VgMG+ce12Osmat1gO/KEN3ASY5g==", null, false, "9d4bbcc8-f82f-480f-b78e-8b12a6c8804f", false, "Moderator" },
                    { "757d5290-d036-4757-85ae-827b59e92cd3", 0, "5fb35cec-8188-410f-b1f7-6f4054d0f2e4", "administrator@mail.ru", false, false, null, "ADMINISTRATOR@MAIL.RU", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEOY+nDEs47wEqSuu5eP6Q2YTZkZ8bmC4hfIWg42tPthr4157euv0duJB0utE/SJI6w==", null, false, "3a86553e-4025-4c27-997b-97e1c34ff446", false, "Administrator" },
                    { "64dbb199-0a95-4f1a-afcf-10cc827fd3c8", 0, "0c8490d4-5b4e-49b8-9281-d93054a754e4", "user1@mail.ru", false, false, null, "USER1@MAIL.RU", "USER1", "AQAAAAEAACcQAAAAEL7OUJwY+QJc1YDITj6Y44cfTcoNx4EJjJJ7+GDMOdy+pC41UjkkLif3wZrbs+ewkA==", null, false, "691bfd0e-5a73-42d9-a24d-9d314c6ad174", false, "User1" }
                });

            migrationBuilder.InsertData(
                table: "DomainUsers",
                columns: new[] { "Id", "Address", "CreatedAt", "FirstName", "IsDeleted", "LastName", "MiddleName", "PhoneNumber", "RegionId", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { "09c529c8-e798-44ac-9eac-e0150182fa4c", "299314 г. Симферополь, ул. Чернышевского, 4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Василий", false, "Максимов", "Андреевич", "+79485733234", 4, null, "vas_andr_4" },
                    { "757d5290-d036-4757-85ae-827b59e92cd3", "299011 г. Севастополь, ул. Чехова, 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrator", false, "Administrator", "Administrator", "+79787713935", 1, null, "Administrator" },
                    { "a0d74199-2ad5-4d2f-a184-eb52f5bf9094", "299011 г. Севастополь, ул. Гоголя, 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moderator", false, "Moderator", "Moderator", "+79787713935", 1, null, "Moderator" },
                    { "64dbb199-0a95-4f1a-afcf-10cc827fd3c8", "299411 г. Москва, ул. Тургенева, 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Александр", false, "Викторович", "Булгаков", "+79787713931", 1, null, "alex_1" },
                    { "54b1ff98-6b5f-4c5e-97a9-747095e1f5dc", "299812 г. Судак, ул. Сергеева, 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Роман", false, "Сидоров", "Олегович", "+79787713932", 2, null, "sidor2" },
                    { "c191e5f8-bf5b-40a9-9ab6-4d08704e373b", "299713 г. Керчь, ул. Куприна, 3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Иван", false, "Иванов", "Иванович", "+79787713933", 3, null, "ivanov3" },
                    { "7e24ccd2-34fd-4289-9a78-1aae93623bae", "299415 г. Ялта, ул. Достоевского, 5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Пётр", false, "Иванов", "Сергеевич", "+79687416935", 5, null, "petr_ivanov_5" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "cc836c4d-a3dd-4434-92f3-f45a9ed19dd3", "757d5290-d036-4757-85ae-827b59e92cd3" },
                    { "c373fe1b-9e38-498b-9729-6c719222b00d", "a0d74199-2ad5-4d2f-a184-eb52f5bf9094" },
                    { "589a1f42-d43c-4315-8e02-432f64e02bc0", "64dbb199-0a95-4f1a-afcf-10cc827fd3c8" },
                    { "589a1f42-d43c-4315-8e02-432f64e02bc0", "54b1ff98-6b5f-4c5e-97a9-747095e1f5dc" },
                    { "589a1f42-d43c-4315-8e02-432f64e02bc0", "c191e5f8-bf5b-40a9-9ab6-4d08704e373b" },
                    { "589a1f42-d43c-4315-8e02-432f64e02bc0", "09c529c8-e798-44ac-9eac-e0150182fa4c" },
                    { "589a1f42-d43c-4315-8e02-432f64e02bc0", "7e24ccd2-34fd-4289-9a78-1aae93623bae" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteAdvertisementUser_UsersId",
                table: "FavoriteAdvertisementUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserUser_IgnoredUsersId",
                table: "UserUser",
                column: "IgnoredUsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "FavoriteAdvertisementUser");

            migrationBuilder.DropTable(
                name: "UserUser");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "FavoriteAdvertisement");

            migrationBuilder.DropTable(
                name: "DomainUsers");
        }
    }
}
