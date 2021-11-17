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
                    { "cc836c4d-a3dd-4434-92f3-f45a9ed19dd3", "05443452-4179-4470-b228-3c58711b924a", "Administrator", "ADMINISTRATOR" },
                    { "c373fe1b-9e38-498b-9729-6c719222b00d", "bd833ca9-df41-4c26-8c2e-2b37d17c08d2", "Moderator", "MODERATOR" },
                    { "589a1f42-d43c-4315-8e02-432f64e02bc0", "9f9c6892-1c71-4d03-a1e5-dde84839f7e2", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "757d5290-d036-4757-85ae-827b59e92cd3", 0, "ba806f87-3783-4337-9e95-31503c9f66bb", "administrator@mail.ru", false, false, null, "ADMINISTRATOR@MAIL.RU", "ADMINISTRATOR", "AQAAAAEAACcQAAAAELWpr93gKIBYeUiec/g0AgEs+TDQqspOJDfTPIQzoNh688kJNRn/zZqjlI7ctT6aqg==", null, false, "2136d1ab-2579-43ae-88ae-9bb091d6584d", false, "Administrator" },
                    { "a0d74199-2ad5-4d2f-a184-eb52f5bf9094", 0, "2e96667e-036e-4380-9aff-26e594f9633d", "moderator@mail.ru", false, false, null, "MODERATOR@MAIL.RU", "MODERATOR", "AQAAAAEAACcQAAAAEFgQWT1fgw5rjWHf/Xc85pTIwLqR1yXL133tI9FPdesk4PWeVlg4EXT5p8/zHoXHRQ==", null, false, "46ce0d4b-cc45-49f0-8e94-5dfbac27f15f", false, "Moderator" },
                    { "64dbb199-0a95-4f1a-afcf-10cc827fd3c8", 0, "23850d4b-d70c-45c6-8c2d-609192e5d329", "user@mail.ru", false, false, null, "USER@MAIL.RU", "USER", "AQAAAAEAACcQAAAAED7o/pGv/KS7EVmCI2wxtP1CwJ/XSStblpvqXVJIXRdsk/OEBpSnxM6pCvWCpXWI4w==", null, false, "e3d1de0a-5988-4bca-8ea8-cb66999a87cb", false, "User" }
                });

            migrationBuilder.InsertData(
                table: "DomainUsers",
                columns: new[] { "Id", "Address", "CreatedAt", "FirstName", "IsDeleted", "LastName", "MiddleName", "PhoneNumber", "RegionId", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { "757d5290-d036-4757-85ae-827b59e92cd3", "99011 г. Севастополь, ул. Чехова, 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrator", false, "Administrator", "Administrator", "+79787713935", 1, null, "Administrator" },
                    { "a0d74199-2ad5-4d2f-a184-eb52f5bf9094", "99011 г. Севастополь, ул. Гоголя, 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moderator", false, "Moderator", "Moderator", "+79787713935", 1, null, "Moderator" },
                    { "64dbb199-0a95-4f1a-afcf-10cc827fd3c8", "99011 г. Севастополь, ул. Достоевского, 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", false, "User", "User", "+79787713935", 1, null, "User" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cc836c4d-a3dd-4434-92f3-f45a9ed19dd3", "757d5290-d036-4757-85ae-827b59e92cd3" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c373fe1b-9e38-498b-9729-6c719222b00d", "a0d74199-2ad5-4d2f-a184-eb52f5bf9094" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "589a1f42-d43c-4315-8e02-432f64e02bc0", "64dbb199-0a95-4f1a-afcf-10cc827fd3c8" });

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
