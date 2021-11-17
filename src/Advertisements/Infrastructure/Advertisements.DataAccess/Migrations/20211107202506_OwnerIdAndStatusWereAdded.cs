using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Advertisements.DataAccess.Migrations
{
    public partial class OwnerIdAndStatusWereAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Advertisements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Advertisements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(2888));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name", "ParentCategoryId" },
                values: new object[] { new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3398), "Автомобили", 1 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name", "ParentCategoryId" },
                values: new object[] { new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3641), "Мотоциклы и мототехника", 1 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Name", "ParentCategoryId" },
                values: new object[] { new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3644), "Грузовики и спецтехника", 1 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3645), "Недвижимость" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Name", "ParentCategoryId" },
                values: new object[] { new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3877), "Квартиры", 5 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "ParentCategoryId", "UpdatedAt" },
                values: new object[,]
                {
                    { 7, new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3879), false, "Комнаты", 5, null },
                    { 8, new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3880), false, "Дома, дачи, коттеджи", 5, null },
                    { 9, new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3881), false, "Электроника", null, null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "ParentCategoryId", "UpdatedAt" },
                values: new object[,]
                {
                    { 10, new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3882), false, "Аудио и видео", 9, null },
                    { 11, new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3883), false, "Игры, приставки и программы", 9, null },
                    { 12, new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3884), false, "Настольные компьютеры", 9, null },
                    { 13, new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3885), false, "Ноутбуки", 9, null },
                    { 14, new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3886), false, "Планшеты и электронные книги", 9, null },
                    { 15, new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3887), false, "Телефоны", 9, null },
                    { 16, new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3888), false, "Товары для компьютера", 9, null },
                    { 17, new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3889), false, "Фототехника", 9, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Advertisements");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 6, 6, 16, 12, 666, DateTimeKind.Utc).AddTicks(6887));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name", "ParentCategoryId" },
                values: new object[] { new DateTime(2021, 9, 6, 6, 16, 12, 666, DateTimeKind.Utc).AddTicks(8607), "Недвижимость", null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name", "ParentCategoryId" },
                values: new object[] { new DateTime(2021, 9, 6, 6, 16, 12, 666, DateTimeKind.Utc).AddTicks(8613), "Мебель", null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Name", "ParentCategoryId" },
                values: new object[] { new DateTime(2021, 9, 6, 6, 16, 12, 666, DateTimeKind.Utc).AddTicks(8640), "Одежда", null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2021, 9, 6, 6, 16, 12, 666, DateTimeKind.Utc).AddTicks(8642), "Бытовая техника" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Name", "ParentCategoryId" },
                values: new object[] { new DateTime(2021, 9, 6, 6, 16, 12, 666, DateTimeKind.Utc).AddTicks(8644), "Книги", null });
        }
    }
}
