using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Advertisements.DataAccess.Migrations
{
    public partial class UserFilesWereAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileId = table.Column<int>(type: "int", nullable: true),
                    AdvertisementId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFiles_Advertisements_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "Advertisements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 101, DateTimeKind.Utc).AddTicks(3692));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 101, DateTimeKind.Utc).AddTicks(4157));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 101, DateTimeKind.Utc).AddTicks(4160));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 101, DateTimeKind.Utc).AddTicks(4162));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 101, DateTimeKind.Utc).AddTicks(4163));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 101, DateTimeKind.Utc).AddTicks(4164));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 101, DateTimeKind.Utc).AddTicks(4166));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 101, DateTimeKind.Utc).AddTicks(4167));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 101, DateTimeKind.Utc).AddTicks(4168));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 101, DateTimeKind.Utc).AddTicks(4170));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 101, DateTimeKind.Utc).AddTicks(4171));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 101, DateTimeKind.Utc).AddTicks(4172));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 101, DateTimeKind.Utc).AddTicks(4174));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 101, DateTimeKind.Utc).AddTicks(4175));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 101, DateTimeKind.Utc).AddTicks(4176));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 101, DateTimeKind.Utc).AddTicks(4177));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 101, DateTimeKind.Utc).AddTicks(4179));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 101, DateTimeKind.Utc).AddTicks(4180));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 101, DateTimeKind.Utc).AddTicks(4181));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 101, DateTimeKind.Utc).AddTicks(4182));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 101, DateTimeKind.Utc).AddTicks(4184));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 101, DateTimeKind.Utc).AddTicks(4185));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 101, DateTimeKind.Utc).AddTicks(4186));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 101, DateTimeKind.Utc).AddTicks(4187));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 101, DateTimeKind.Utc).AddTicks(4217));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 118, DateTimeKind.Utc).AddTicks(6244));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 118, DateTimeKind.Utc).AddTicks(7153));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 118, DateTimeKind.Utc).AddTicks(7580));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 118, DateTimeKind.Utc).AddTicks(7583));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 118, DateTimeKind.Utc).AddTicks(7584));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 118, DateTimeKind.Utc).AddTicks(7586));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 118, DateTimeKind.Utc).AddTicks(7587));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 118, DateTimeKind.Utc).AddTicks(7588));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 118, DateTimeKind.Utc).AddTicks(7589));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 118, DateTimeKind.Utc).AddTicks(7590));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 118, DateTimeKind.Utc).AddTicks(7592));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 118, DateTimeKind.Utc).AddTicks(7593));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 118, DateTimeKind.Utc).AddTicks(7594));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 118, DateTimeKind.Utc).AddTicks(7595));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 118, DateTimeKind.Utc).AddTicks(7597));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 118, DateTimeKind.Utc).AddTicks(7598));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 118, DateTimeKind.Utc).AddTicks(7599));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "ParentCategoryId", "UpdatedAt" },
                values: new object[] { 18, new DateTime(2021, 11, 26, 15, 2, 22, 118, DateTimeKind.Utc).AddTicks(7600), false, "Искусство", null, null });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 123, DateTimeKind.Utc).AddTicks(9973));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(452));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(455));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(456));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(458));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(459));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(460));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(461));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(462));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(463));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(496));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(498));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(499));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(500));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(501));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(502));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(503));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(504));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(505));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(506));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(507));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(508));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(509));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(510));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(511));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(512));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(514));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(515));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(516));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(517));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(518));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(519));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(520));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(521));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(522));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(523));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(524));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(525));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(526));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(528));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(529));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(530));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(531));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(532));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(533));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(534));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(535));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(536));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(537));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(538));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(539));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(540));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(541));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(542));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(543));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(544));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(545));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(546));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(547));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(548));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(549));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(550));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(551));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(552));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(553));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(554));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(556));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(557));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(558));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(559));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(560));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(561));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(562));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(563));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(564));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(565));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(566));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(567));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(568));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(569));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(570));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(571));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(572));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(573));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(574));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(575));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(576));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(577));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(578));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(579));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(580));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(581));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(583));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(584));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(585));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(586));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(587));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(588));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 26, 15, 2, 22, 124, DateTimeKind.Utc).AddTicks(589));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "ParentCategoryId", "UpdatedAt" },
                values: new object[] { 19, new DateTime(2021, 11, 26, 15, 2, 22, 118, DateTimeKind.Utc).AddTicks(7601), false, "Живопись маслом", 18, null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "ParentCategoryId", "UpdatedAt" },
                values: new object[] { 20, new DateTime(2021, 11, 26, 15, 2, 22, 118, DateTimeKind.Utc).AddTicks(7602), false, "Акварель", 18, null });

            migrationBuilder.CreateIndex(
                name: "IX_UserFiles_AdvertisementId",
                table: "UserFiles",
                column: "AdvertisementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFiles");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 6, DateTimeKind.Utc).AddTicks(9406));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 6, DateTimeKind.Utc).AddTicks(9707));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 6, DateTimeKind.Utc).AddTicks(9710));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 6, DateTimeKind.Utc).AddTicks(9711));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 6, DateTimeKind.Utc).AddTicks(9712));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 6, DateTimeKind.Utc).AddTicks(9713));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 6, DateTimeKind.Utc).AddTicks(9715));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 6, DateTimeKind.Utc).AddTicks(9716));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 6, DateTimeKind.Utc).AddTicks(9717));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 6, DateTimeKind.Utc).AddTicks(9718));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 6, DateTimeKind.Utc).AddTicks(9720));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 6, DateTimeKind.Utc).AddTicks(9721));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 6, DateTimeKind.Utc).AddTicks(9722));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 6, DateTimeKind.Utc).AddTicks(9723));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 6, DateTimeKind.Utc).AddTicks(9724));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 6, DateTimeKind.Utc).AddTicks(9726));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 6, DateTimeKind.Utc).AddTicks(9727));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 6, DateTimeKind.Utc).AddTicks(9728));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 6, DateTimeKind.Utc).AddTicks(9729));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 6, DateTimeKind.Utc).AddTicks(9730));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 6, DateTimeKind.Utc).AddTicks(9732));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 6, DateTimeKind.Utc).AddTicks(9733));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 6, DateTimeKind.Utc).AddTicks(9734));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 6, DateTimeKind.Utc).AddTicks(9735));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 6, DateTimeKind.Utc).AddTicks(9736));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 19, DateTimeKind.Utc).AddTicks(4691));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 19, DateTimeKind.Utc).AddTicks(5221));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 19, DateTimeKind.Utc).AddTicks(5478));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 19, DateTimeKind.Utc).AddTicks(5480));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 19, DateTimeKind.Utc).AddTicks(5481));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 19, DateTimeKind.Utc).AddTicks(5482));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 19, DateTimeKind.Utc).AddTicks(5484));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 19, DateTimeKind.Utc).AddTicks(5485));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 19, DateTimeKind.Utc).AddTicks(5486));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 19, DateTimeKind.Utc).AddTicks(5487));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 19, DateTimeKind.Utc).AddTicks(5488));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 19, DateTimeKind.Utc).AddTicks(5489));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 19, DateTimeKind.Utc).AddTicks(5490));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 19, DateTimeKind.Utc).AddTicks(5491));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 19, DateTimeKind.Utc).AddTicks(5492));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 19, DateTimeKind.Utc).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 19, DateTimeKind.Utc).AddTicks(5494));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(8894));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9185));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9187));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9188));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9189));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9190));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9191));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9192));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9193));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9194));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9195));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9196));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9197));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9198));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9199));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9200));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9201));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9202));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9203));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9203));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9204));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9205));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9206));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9207));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9208));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9209));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9210));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9211));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9212));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9213));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9214));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9215));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9216));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9217));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9218));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9219));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9219));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9220));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9221));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9222));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9223));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9224));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9225));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9226));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9227));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9228));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9229));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9230));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9231));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9232));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9233));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9234));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9235));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9236));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9237));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9238));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9239));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9240));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9240));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9241));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9242));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9243));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9244));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9245));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9246));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9247));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9248));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9249));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9250));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9251));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9252));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9253));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9254));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9255));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9255));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9256));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9257));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9258));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9259));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9260));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9261));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9262));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9263));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9264));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9265));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9266));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9267));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9268));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9269));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9270));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9271));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9271));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9272));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9312));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9313));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9314));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9315));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9316));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 23, 13, 2, 23, DateTimeKind.Utc).AddTicks(9317));
        }
    }
}
