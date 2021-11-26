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
                value: new DateTime(2021, 11, 24, 21, 55, 35, 671, DateTimeKind.Utc).AddTicks(8862));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 671, DateTimeKind.Utc).AddTicks(9117));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 671, DateTimeKind.Utc).AddTicks(9120));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 671, DateTimeKind.Utc).AddTicks(9121));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 671, DateTimeKind.Utc).AddTicks(9123));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 671, DateTimeKind.Utc).AddTicks(9124));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 671, DateTimeKind.Utc).AddTicks(9125));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 671, DateTimeKind.Utc).AddTicks(9126));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 671, DateTimeKind.Utc).AddTicks(9127));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 671, DateTimeKind.Utc).AddTicks(9129));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 671, DateTimeKind.Utc).AddTicks(9130));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 671, DateTimeKind.Utc).AddTicks(9131));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 671, DateTimeKind.Utc).AddTicks(9132));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 671, DateTimeKind.Utc).AddTicks(9133));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 671, DateTimeKind.Utc).AddTicks(9135));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 671, DateTimeKind.Utc).AddTicks(9136));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 671, DateTimeKind.Utc).AddTicks(9137));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 671, DateTimeKind.Utc).AddTicks(9138));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 671, DateTimeKind.Utc).AddTicks(9139));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 671, DateTimeKind.Utc).AddTicks(9140));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 671, DateTimeKind.Utc).AddTicks(9141));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 671, DateTimeKind.Utc).AddTicks(9143));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 671, DateTimeKind.Utc).AddTicks(9144));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 671, DateTimeKind.Utc).AddTicks(9145));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 671, DateTimeKind.Utc).AddTicks(9146));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 684, DateTimeKind.Utc).AddTicks(4628));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 684, DateTimeKind.Utc).AddTicks(5165));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 684, DateTimeKind.Utc).AddTicks(5421));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 684, DateTimeKind.Utc).AddTicks(5424));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 684, DateTimeKind.Utc).AddTicks(5425));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 684, DateTimeKind.Utc).AddTicks(5426));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 684, DateTimeKind.Utc).AddTicks(5427));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 684, DateTimeKind.Utc).AddTicks(5428));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 684, DateTimeKind.Utc).AddTicks(5429));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 684, DateTimeKind.Utc).AddTicks(5430));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 684, DateTimeKind.Utc).AddTicks(5431));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 684, DateTimeKind.Utc).AddTicks(5432));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 684, DateTimeKind.Utc).AddTicks(5433));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 684, DateTimeKind.Utc).AddTicks(5434));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 684, DateTimeKind.Utc).AddTicks(5435));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 684, DateTimeKind.Utc).AddTicks(5436));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 684, DateTimeKind.Utc).AddTicks(5437));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(380));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(657));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(660));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(661));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(662));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(663));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(664));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(665));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(666));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(667));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(668));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(669));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(670));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(671));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(672));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(673));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(674));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(675));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(676));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(677));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(678));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(678));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(680));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(682));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(683));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(684));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(685));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(686));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(687));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(688));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(689));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(690));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(691));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(693));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(694));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(695));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(696));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(697));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(697));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(698));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(699));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(700));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(701));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(702));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(741));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(742));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(743));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(744));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(745));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(746));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(747));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(748));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(749));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(750));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(751));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(752));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(753));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(754));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(755));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(756));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(757));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(758));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(759));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(760));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(761));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(762));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(763));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(764));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(765));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(766));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(768));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(768));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(770));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(771));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(772));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(773));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(774));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(775));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(776));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(777));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(778));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(779));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(780));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(781));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(782));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(783));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(784));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(785));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(786));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(787));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(788));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(789));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(790));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(791));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(792));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(793));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 24, 21, 55, 35, 689, DateTimeKind.Utc).AddTicks(794));

            migrationBuilder.CreateIndex(
                name: "IX_UserFiles_AdvertisementId",
                table: "UserFiles",
                column: "AdvertisementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFiles");

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
