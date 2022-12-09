using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Accounts.DataAccess.Migrations
{
    public partial class Initial_Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DomainUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    RegionId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteAdvertisement",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    AdvertisementId = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteAdvertisement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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
                    FriendUsersId = table.Column<string>(type: "text", nullable: false),
                    IgnoredUsersId = table.Column<string>(type: "text", nullable: false)
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteAdvertisementUser",
                columns: table => new
                {
                    FavoriteAdvertisementsId = table.Column<string>(type: "text", nullable: false),
                    UsersId = table.Column<string>(type: "text", nullable: false)
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
                        name: "FK_FavoriteAdvertisementUser_FavoriteAdvertisement_FavoriteAdv~",
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
                    { "cc836c4d-a3dd-4434-92f3-f45a9ed19dd3", "1e7ea002-2501-47e5-b5f7-4a21a40f28e8", "Administrator", "ADMINISTRATOR" },
                    { "c373fe1b-9e38-498b-9729-6c719222b00d", "76a944c8-b598-4446-ad4b-251110759a08", "Moderator", "MODERATOR" },
                    { "589a1f42-d43c-4315-8e02-432f64e02bc0", "435a6a18-75d6-4512-bb18-6d5bcd1acc40", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7e24ccd2-34fd-4289-9a78-1aae93623bae", 0, "a0cf9bd0-2dfd-40a1-bdd8-e592140cedd4", "user5@mail.ru", false, false, null, "USER5@MAIL.RU", "USER5", "AQAAAAEAACcQAAAAELb0hQWP4T/JFCcAfLQkg+LCT6Dgsp8fcSAcV+CtlYRMDNsi+Pyerg9/yP02XTxDvw==", null, false, "f591dacb-6664-48f0-8b82-da6123c9f1b2", false, "User5" },
                    { "c191e5f8-bf5b-40a9-9ab6-4d08704e373b", 0, "c1359c92-6c45-421f-ac2e-4002c54435d1", "user3@mail.ru", false, false, null, "USER3@MAIL.RU", "USER3", "AQAAAAEAACcQAAAAEA+xTjhdOyThf6UgHbA1bS7D0RHka1Nb5KD5/7oBsG1H3Ab1kzKMfe09d6E1IZNgdQ==", null, false, "b1b366e0-07b5-42c9-95d1-ec8699d02713", false, "User3" },
                    { "54b1ff98-6b5f-4c5e-97a9-747095e1f5dc", 0, "040d3204-408b-49a5-9fad-52d56396530f", "user2@mail.ru", false, false, null, "USER2@MAIL.RU", "USER2", "AQAAAAEAACcQAAAAEEv5UdqFzWn9LiCZ7/XMMuj8ZwfGpqqqNTVNhEnncn6+FWL1Y5ititIvl7Uvzf0pmA==", null, false, "a0a65d52-0fc1-4a69-a9bd-6e076df2525a", false, "User2" },
                    { "09c529c8-e798-44ac-9eac-e0150182fa4c", 0, "01aae025-18d1-43c4-9ead-0e32d6613f71", "user4@mail.ru", false, false, null, "USER4@MAIL.RU", "USER4", "AQAAAAEAACcQAAAAEE5zoSeEk/UEjRtlswW+CtmyvQe+PQM1hpp7K22VAjsxXAGISN5zZoRoXmVzca+iRA==", null, false, "07efd003-fb14-4bcc-8f3f-3f2f6459e42e", false, "User4" },
                    { "a0d74199-2ad5-4d2f-a184-eb52f5bf9094", 0, "84fa14dd-e722-49d2-b6a1-63405dc52b27", "moderator@mail.ru", false, false, null, "MODERATOR@MAIL.RU", "MODERATOR", "AQAAAAEAACcQAAAAEO/USzQKZENxDHEECjp3n1Mt9DaMQDFXj2dQIo1C03Thc5a7at5rI4zGS/M05eU2RQ==", null, false, "b5a653ba-8a03-447a-8895-778989d06384", false, "Moderator" },
                    { "757d5290-d036-4757-85ae-827b59e92cd3", 0, "30b6f92a-c25d-469c-93b3-74a39a62681c", "administrator@mail.ru", false, false, null, "ADMINISTRATOR@MAIL.RU", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEHbA59k6R9CidRWBBLl1cQw/jGM6Tv6jjBVzOI9+aSIweJFWDQmSrZv2iDwqq7K1vQ==", null, false, "a85197a1-e5e1-428c-a909-968776bf78f8", false, "Administrator" },
                    { "64dbb199-0a95-4f1a-afcf-10cc827fd3c8", 0, "bc119491-4d98-4cbb-a1c3-cc1904fd4a98", "user1@mail.ru", false, false, null, "USER1@MAIL.RU", "USER1", "AQAAAAEAACcQAAAAEEPQ5p8yryXe2TWs1fxIpgAhhRs1ANxbiAHQEDeh6sI3SptpLc4mSEeRG1CZLoQSdQ==", null, false, "52e27e73-3a71-4e1e-80db-d0661d77b2a3", false, "User1" }
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
                    { "54b1ff98-6b5f-4c5e-97a9-747095e1f5dc", "299812 г. Судак, ул. Сергеева, 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Роман", false, "Сидоров", "Олегович", "+79787713932", 2, null, "sidorov_2" },
                    { "c191e5f8-bf5b-40a9-9ab6-4d08704e373b", "299713 г. Керчь, ул. Куприна, 3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Иван", false, "Иванов", "Иванович", "+79787713933", 3, null, "ivanov_3" },
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
                unique: true);

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
                unique: true);

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
