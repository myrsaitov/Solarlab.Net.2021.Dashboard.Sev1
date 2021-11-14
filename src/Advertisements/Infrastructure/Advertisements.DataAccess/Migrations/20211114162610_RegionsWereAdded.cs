using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Advertisements.DataAccess.Migrations
{
    public partial class RegionsWereAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Categories_CategoryId",
                table: "Advertisements");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

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
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.AlterColumn<int>(
                name: "Count",
                table: "Tags",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Advertisements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Advertisements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Advertisements",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentRegionId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regions_Regions_ParentRegionId",
                        column: x => x.ParentRegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "ParentCategoryId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 11, 14, 16, 26, 9, 639, DateTimeKind.Utc).AddTicks(3951), false, "Транспорт", null, null },
                    { 5, new DateTime(2021, 11, 14, 16, 26, 9, 639, DateTimeKind.Utc).AddTicks(4686), false, "Недвижимость", null, null },
                    { 9, new DateTime(2021, 11, 14, 16, 26, 9, 639, DateTimeKind.Utc).AddTicks(4916), false, "Электроника", null, null }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "ParentRegionId", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(7999), false, "Российская Федерация", null, null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "ParentCategoryId", "UpdatedAt" },
                values: new object[,]
                {
                    { 2, new DateTime(2021, 11, 14, 16, 26, 9, 639, DateTimeKind.Utc).AddTicks(4449), false, "Автомобили", 1, null },
                    { 17, new DateTime(2021, 11, 14, 16, 26, 9, 639, DateTimeKind.Utc).AddTicks(4964), false, "Фототехника", 9, null },
                    { 16, new DateTime(2021, 11, 14, 16, 26, 9, 639, DateTimeKind.Utc).AddTicks(4963), false, "Товары для компьютера", 9, null },
                    { 14, new DateTime(2021, 11, 14, 16, 26, 9, 639, DateTimeKind.Utc).AddTicks(4960), false, "Планшеты и электронные книги", 9, null },
                    { 13, new DateTime(2021, 11, 14, 16, 26, 9, 639, DateTimeKind.Utc).AddTicks(4920), false, "Ноутбуки", 9, null },
                    { 12, new DateTime(2021, 11, 14, 16, 26, 9, 639, DateTimeKind.Utc).AddTicks(4919), false, "Настольные компьютеры", 9, null },
                    { 11, new DateTime(2021, 11, 14, 16, 26, 9, 639, DateTimeKind.Utc).AddTicks(4918), false, "Игры, приставки и программы", 9, null },
                    { 15, new DateTime(2021, 11, 14, 16, 26, 9, 639, DateTimeKind.Utc).AddTicks(4962), false, "Телефоны", 9, null },
                    { 8, new DateTime(2021, 11, 14, 16, 26, 9, 639, DateTimeKind.Utc).AddTicks(4915), false, "Дома, дачи, коттеджи", 5, null },
                    { 7, new DateTime(2021, 11, 14, 16, 26, 9, 639, DateTimeKind.Utc).AddTicks(4914), false, "Комнаты", 5, null },
                    { 6, new DateTime(2021, 11, 14, 16, 26, 9, 639, DateTimeKind.Utc).AddTicks(4912), false, "Квартиры", 5, null },
                    { 4, new DateTime(2021, 11, 14, 16, 26, 9, 639, DateTimeKind.Utc).AddTicks(4684), false, "Грузовики и спецтехника", 1, null },
                    { 3, new DateTime(2021, 11, 14, 16, 26, 9, 639, DateTimeKind.Utc).AddTicks(4682), false, "Мотоциклы и мототехника", 1, null },
                    { 10, new DateTime(2021, 11, 14, 16, 26, 9, 639, DateTimeKind.Utc).AddTicks(4917), false, "Аудио и видео", 9, null }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "ParentRegionId", "UpdatedAt" },
                values: new object[,]
                {
                    { 98, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8491), false, "Севастополь", 1, null },
                    { 2, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8283), false, "Центральный федеральный округ", 1, null },
                    { 21, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8305), false, "Северо-Западный федеральный округ", 1, null },
                    { 33, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8376), false, "Южный федеральный округ", 1, null },
                    { 47, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8390), false, "Приволжский федеральный округ", 1, null },
                    { 63, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8407), false, "Уральский федеральный округ", 1, null },
                    { 70, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8414), false, "Сибирский федеральный округ", 1, null },
                    { 87, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8479), false, "Дальневосточный федеральный округ", 1, null },
                    { 99, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8492), false, "Крым", 1, null }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "ParentRegionId", "UpdatedAt" },
                values: new object[,]
                {
                    { 3, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8286), false, "Белгородская область", 2, null },
                    { 71, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8463), false, "Республика Алтай", 70, null },
                    { 69, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8413), false, "в том числе Челябинская область", 63, null },
                    { 68, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8412), false, "в том числе Ямало-Ненецкий автономный округ", 63, null },
                    { 67, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8411), false, "в том числе Ханты-Мансийский автономный округ - Югра", 63, null },
                    { 66, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8410), false, "Тюменская область", 63, null },
                    { 65, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8409), false, "Свердловская область", 63, null },
                    { 64, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8408), false, "Курганская область", 63, null },
                    { 62, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8405), false, "Ульяновская область", 47, null },
                    { 72, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8464), false, "Республика Бурятия", 70, null },
                    { 61, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8404), false, "Саратовская область", 47, null },
                    { 59, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8402), false, "в том числе Коми-Пермяцкий автономный округ", 47, null },
                    { 58, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8401), false, "Пермская область", 47, null },
                    { 57, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8401), false, "Пензенская область", 47, null },
                    { 56, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8400), false, "Оренбургская область", 47, null },
                    { 55, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8398), false, "Нижегородская область", 47, null },
                    { 54, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8397), false, "Кировская область", 47, null },
                    { 53, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8396), false, "Чувашская Республика", 47, null },
                    { 52, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8395), false, "Удмуртская Республика", 47, null },
                    { 60, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8403), false, "Самарская область", 47, null },
                    { 73, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8465), false, "Республика Тыва", 70, null },
                    { 74, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8466), false, "Республика Хакасия", 70, null },
                    { 75, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8467), false, "Алтайский край", 70, null },
                    { 95, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8488), false, "Сахалинская область", 87, null },
                    { 94, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8486), false, "Магаданская область", 87, null },
                    { 93, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8485), false, "Корякский автономный округ", 87, null },
                    { 92, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8484), false, "Камчатская область", 87, null },
                    { 91, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8484), false, "Амурская край", 87, null },
                    { 90, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8483), false, "Хабаровский край", 87, null },
                    { 89, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8481), false, "Приморский край", 87, null },
                    { 88, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8480), false, "Республика Саха (Якутия)", 87, null },
                    { 86, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8478), false, "в том числе Агинский Бурятский автономный округ", 70, null },
                    { 85, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8478), false, "Читинская область", 70, null },
                    { 84, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8477), false, "Томская область", 70, null },
                    { 83, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8475), false, "Омская область", 70, null },
                    { 82, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8474), false, "Новосибирская область", 70, null },
                    { 81, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8473), false, "Кемеровская область", 70, null },
                    { 80, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8472), false, "в том числе Усть-Ордынский Бурятский автономный округ", 70, null },
                    { 79, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8471), false, "Иркутская область", 70, null },
                    { 78, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8470), false, "Эвенкийский автономный округ", 70, null },
                    { 77, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8469), false, "в том числе Таймырский (Долгано-Ненецкий) автономный округ", 70, null },
                    { 76, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8468), false, "Красноярский край", 70, null }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "ParentRegionId", "UpdatedAt" },
                values: new object[,]
                {
                    { 51, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8394), false, "Республика Татарстан", 47, null },
                    { 96, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8489), false, "Еврейская автономная область", 87, null },
                    { 50, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8393), false, "Республика Мордовия", 47, null },
                    { 48, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8391), false, "Республика Башкортостан", 47, null },
                    { 22, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8306), false, "Республика Карелия", 21, null },
                    { 20, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8304), false, "г. Москва", 2, null },
                    { 19, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8303), false, "Ярославская область", 2, null },
                    { 18, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8302), false, "Тульская область", 2, null },
                    { 17, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8301), false, "Тверская область", 2, null },
                    { 16, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8300), false, "Тамбовская область", 2, null },
                    { 15, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8299), false, "Смоленская область", 2, null },
                    { 14, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8298), false, "Рязанская область", 2, null },
                    { 23, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8307), false, "Республика Коми", 21, null },
                    { 13, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8297), false, "Орловская область", 2, null },
                    { 11, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8295), false, "Липецкая область", 2, null },
                    { 10, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8294), false, "Курская область", 2, null },
                    { 9, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8293), false, "Костромская область", 2, null },
                    { 8, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8292), false, "Калужская область", 2, null },
                    { 7, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8291), false, "Ивановская область", 2, null },
                    { 6, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8289), false, "Воронежская область", 2, null },
                    { 5, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8288), false, "Владимирская область", 2, null },
                    { 4, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8287), false, "Брянская область", 2, null },
                    { 12, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8296), false, "Московская область", 2, null },
                    { 24, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8308), false, "Архангельская область", 21, null },
                    { 25, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8309), false, "в том числе Ненецкий автономный округ", 21, null },
                    { 26, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8368), false, "Вологодская область", 21, null },
                    { 46, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8389), false, "Ростовская область", 33, null },
                    { 45, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8388), false, "Волгоградская область", 33, null },
                    { 44, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8387), false, "Астраханская область", 33, null },
                    { 43, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8386), false, "Ставропольский край", 33, null },
                    { 42, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8385), false, "Краснодарский край", 33, null },
                    { 41, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8384), false, "Чеченская Республика", 33, null },
                    { 40, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8383), false, "Республика Северная Осетия - Алания", 33, null },
                    { 39, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8382), false, "Карачаево-Черкесская Республика", 33, null },
                    { 38, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8381), false, "Республика Калмыкия", 33, null },
                    { 37, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8380), false, "Кабардино-Балкарская Республика", 33, null },
                    { 36, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8379), false, "Республика Ингушетия", 33, null },
                    { 35, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8378), false, "Республика Дагестан", 33, null },
                    { 34, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8377), false, "Республика Адыгея", 33, null },
                    { 32, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8375), false, "г. Санкт-Петербург", 21, null },
                    { 31, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8374), false, "Псковская область", 21, null },
                    { 30, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8373), false, "Новгородская область", 21, null }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "ParentRegionId", "UpdatedAt" },
                values: new object[,]
                {
                    { 29, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8372), false, "Мурманская область", 21, null },
                    { 28, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8371), false, "Ленинградская область", 21, null },
                    { 27, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8370), false, "Калининградская область", 21, null },
                    { 49, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8392), false, "Республика Марий Эл", 47, null },
                    { 97, new DateTime(2021, 11, 14, 16, 26, 9, 644, DateTimeKind.Utc).AddTicks(8490), false, "Чукотский автономный округ", 87, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_RegionId",
                table: "Advertisements",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_ParentRegionId",
                table: "Regions",
                column: "ParentRegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Categories_CategoryId",
                table: "Advertisements",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Regions_RegionId",
                table: "Advertisements",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Categories_CategoryId",
                table: "Advertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Regions_RegionId",
                table: "Advertisements");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropIndex(
                name: "IX_Advertisements_RegionId",
                table: "Advertisements");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

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
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Advertisements");

            migrationBuilder.AlterColumn<int>(
                name: "Count",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Tags",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Advertisements",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "ParentCategoryId", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(2888), false, "Транспорт", null, null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "ParentCategoryId", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3645), false, "Недвижимость", null, null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "ParentCategoryId", "UpdatedAt" },
                values: new object[] { 9, new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3881), false, "Электроника", null, null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "ParentCategoryId", "UpdatedAt" },
                values: new object[,]
                {
                    { 2, new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3398), false, "Автомобили", 1, null },
                    { 3, new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3641), false, "Мотоциклы и мототехника", 1, null },
                    { 4, new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3644), false, "Грузовики и спецтехника", 1, null },
                    { 6, new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3877), false, "Квартиры", 5, null },
                    { 7, new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3879), false, "Комнаты", 5, null },
                    { 8, new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3880), false, "Дома, дачи, коттеджи", 5, null },
                    { 10, new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3882), false, "Аудио и видео", 9, null },
                    { 11, new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3883), false, "Игры, приставки и программы", 9, null },
                    { 12, new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3884), false, "Настольные компьютеры", 9, null },
                    { 13, new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3885), false, "Ноутбуки", 9, null },
                    { 14, new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3886), false, "Планшеты и электронные книги", 9, null },
                    { 15, new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3887), false, "Телефоны", 9, null },
                    { 16, new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3888), false, "Товары для компьютера", 9, null },
                    { 17, new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3889), false, "Фототехника", 9, null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Categories_CategoryId",
                table: "Advertisements",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
