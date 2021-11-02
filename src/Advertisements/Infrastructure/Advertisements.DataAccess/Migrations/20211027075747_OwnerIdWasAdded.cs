using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Advertisements.DataAccess.Migrations
{
    public partial class OwnerIdWasAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Advertisements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 7, 57, 46, 540, DateTimeKind.Utc).AddTicks(1538));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 7, 57, 46, 540, DateTimeKind.Utc).AddTicks(3025));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 7, 57, 46, 540, DateTimeKind.Utc).AddTicks(3035));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 7, 57, 46, 540, DateTimeKind.Utc).AddTicks(3038));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 7, 57, 46, 540, DateTimeKind.Utc).AddTicks(3040));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 7, 57, 46, 540, DateTimeKind.Utc).AddTicks(3041));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
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
                column: "CreatedAt",
                value: new DateTime(2021, 9, 6, 6, 16, 12, 666, DateTimeKind.Utc).AddTicks(8607));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 6, 6, 16, 12, 666, DateTimeKind.Utc).AddTicks(8613));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 6, 6, 16, 12, 666, DateTimeKind.Utc).AddTicks(8640));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 6, 6, 16, 12, 666, DateTimeKind.Utc).AddTicks(8642));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 6, 6, 16, 12, 666, DateTimeKind.Utc).AddTicks(8644));
        }
    }
}
