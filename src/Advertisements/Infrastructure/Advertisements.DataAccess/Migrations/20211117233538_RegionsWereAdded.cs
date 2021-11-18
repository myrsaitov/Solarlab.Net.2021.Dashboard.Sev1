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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    { 1, new DateTime(2021, 11, 17, 23, 35, 37, 620, DateTimeKind.Utc).AddTicks(3652), false, "Транспорт", null, null },
                    { 5, new DateTime(2021, 11, 17, 23, 35, 37, 620, DateTimeKind.Utc).AddTicks(4200), false, "Недвижимость", null, null },
                    { 9, new DateTime(2021, 11, 17, 23, 35, 37, 620, DateTimeKind.Utc).AddTicks(4439), false, "Электроника", null, null }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CreatedAt", "Name", "ParentRegionId" },
                values: new object[] { 1, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(7816), "Российская Федерация", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "ParentCategoryId", "UpdatedAt" },
                values: new object[,]
                {
                    { 2, new DateTime(2021, 11, 17, 23, 35, 37, 620, DateTimeKind.Utc).AddTicks(3938), false, "Автомобили", 1, null },
                    { 17, new DateTime(2021, 11, 17, 23, 35, 37, 620, DateTimeKind.Utc).AddTicks(4447), false, "Фототехника", 9, null },
                    { 16, new DateTime(2021, 11, 17, 23, 35, 37, 620, DateTimeKind.Utc).AddTicks(4446), false, "Товары для компьютера", 9, null },
                    { 14, new DateTime(2021, 11, 17, 23, 35, 37, 620, DateTimeKind.Utc).AddTicks(4444), false, "Планшеты и электронные книги", 9, null },
                    { 13, new DateTime(2021, 11, 17, 23, 35, 37, 620, DateTimeKind.Utc).AddTicks(4443), false, "Ноутбуки", 9, null },
                    { 12, new DateTime(2021, 11, 17, 23, 35, 37, 620, DateTimeKind.Utc).AddTicks(4442), false, "Настольные компьютеры", 9, null },
                    { 11, new DateTime(2021, 11, 17, 23, 35, 37, 620, DateTimeKind.Utc).AddTicks(4441), false, "Игры, приставки и программы", 9, null },
                    { 15, new DateTime(2021, 11, 17, 23, 35, 37, 620, DateTimeKind.Utc).AddTicks(4445), false, "Телефоны", 9, null },
                    { 8, new DateTime(2021, 11, 17, 23, 35, 37, 620, DateTimeKind.Utc).AddTicks(4438), false, "Дома, дачи, коттеджи", 5, null },
                    { 7, new DateTime(2021, 11, 17, 23, 35, 37, 620, DateTimeKind.Utc).AddTicks(4437), false, "Комнаты", 5, null },
                    { 6, new DateTime(2021, 11, 17, 23, 35, 37, 620, DateTimeKind.Utc).AddTicks(4435), false, "Квартиры", 5, null },
                    { 4, new DateTime(2021, 11, 17, 23, 35, 37, 620, DateTimeKind.Utc).AddTicks(4199), false, "Грузовики и спецтехника", 1, null },
                    { 3, new DateTime(2021, 11, 17, 23, 35, 37, 620, DateTimeKind.Utc).AddTicks(4196), false, "Мотоциклы и мототехника", 1, null },
                    { 10, new DateTime(2021, 11, 17, 23, 35, 37, 620, DateTimeKind.Utc).AddTicks(4440), false, "Аудио и видео", 9, null }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CreatedAt", "Name", "ParentRegionId" },
                values: new object[,]
                {
                    { 98, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8247), "Севастополь", 1 },
                    { 2, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8110), "Центральный федеральный округ", 1 },
                    { 21, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8174), "Северо-Западный федеральный округ", 1 },
                    { 33, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8186), "Южный федеральный округ", 1 },
                    { 47, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8199), "Приволжский федеральный округ", 1 },
                    { 63, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8214), "Уральский федеральный округ", 1 },
                    { 70, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8221), "Сибирский федеральный округ", 1 },
                    { 87, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8236), "Дальневосточный федеральный округ", 1 },
                    { 99, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8247), "Крым", 1 }
                });

            migrationBuilder.InsertData(
                table: "Advertisements",
                columns: new[] { "Id", "Address", "Body", "CategoryId", "CreatedAt", "IsDeleted", "OwnerId", "Price", "RegionId", "Status", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "299411 г. Москва, ул. Тургенева, 1", "Телевизор Xiaomi Mi TV 4S 50, 50, Ultra HD 4K", 10, new DateTime(2021, 11, 17, 23, 35, 37, 608, DateTimeKind.Utc).AddTicks(121), false, "64dbb199-0a95-4f1a-afcf-10cc827fd3c8", 40000m, 1, 0, "Продам телевизор", null },
                    { 9, "299411 г. Москва, ул. Тургенева, 1", "Телевизор Xiaomi Mi TV 4S 50, 50, Ultra HD 4K", 10, new DateTime(2021, 11, 17, 23, 35, 37, 608, DateTimeKind.Utc).AddTicks(392), false, "64dbb199-0a95-4f1a-afcf-10cc827fd3c8", 40000m, 1, 0, "Продам телевизор", null },
                    { 2, "299812 г. Судак, ул. Сергеева, 2", "Магнитофон (от магнит и греч. φωνή звук) — электромеханическое устройство, предназначенное для записи звуковой информации на магнитные носители и/или её воспроизведения. В качестве носителя используются материалы с магнитными свойствами: магнитная лента, проволока, магнитные манжеты, диски, барабаны и т. д.", 10, new DateTime(2021, 11, 17, 23, 35, 37, 608, DateTimeKind.Utc).AddTicks(376), false, "54b1ff98-6b5f-4c5e-97a9-747095e1f5dc", 2000m, 2, 0, "Продам магнитофон", null },
                    { 10, "299812 г. Судак, ул. Сергеева, 2", "Магнитофон (от магнит и греч. φωνή звук) — электромеханическое устройство, предназначенное для записи звуковой информации на магнитные носители и/или её воспроизведения. В качестве носителя используются материалы с магнитными свойствами: магнитная лента, проволока, магнитные манжеты, диски, барабаны и т. д.", 10, new DateTime(2021, 11, 17, 23, 35, 37, 608, DateTimeKind.Utc).AddTicks(394), false, "54b1ff98-6b5f-4c5e-97a9-747095e1f5dc", 2000m, 2, 0, "Продам магнитофон", null }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CreatedAt", "Name", "ParentRegionId" },
                values: new object[,]
                {
                    { 71, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8222), "Республика Алтай", 70 },
                    { 69, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8220), "в том числе Челябинская область", 63 },
                    { 68, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8219), "в том числе Ямало-Ненецкий автономный округ", 63 },
                    { 67, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8218), "в том числе Ханты-Мансийский автономный округ - Югра", 63 },
                    { 66, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8217), "Тюменская область", 63 },
                    { 65, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8216), "Свердловская область", 63 },
                    { 64, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8215), "Курганская область", 63 },
                    { 62, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8213), "Ульяновская область", 47 },
                    { 61, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8212), "Саратовская область", 47 },
                    { 59, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8210), "в том числе Коми-Пермяцкий автономный округ", 47 },
                    { 72, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8223), "Республика Бурятия", 70 },
                    { 58, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8209), "Пермская область", 47 },
                    { 57, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8208), "Пензенская область", 47 },
                    { 56, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8207), "Оренбургская область", 47 },
                    { 55, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8207), "Нижегородская область", 47 },
                    { 54, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8206), "Кировская область", 47 },
                    { 53, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8205), "Чувашская Республика", 47 },
                    { 52, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8204), "Удмуртская Республика", 47 },
                    { 60, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8211), "Самарская область", 47 },
                    { 73, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8224), "Республика Тыва", 70 },
                    { 75, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8225), "Алтайский край", 70 },
                    { 51, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8203), "Республика Татарстан", 47 },
                    { 95, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8244), "Сахалинская область", 87 },
                    { 94, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8243), "Магаданская область", 87 },
                    { 93, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8242), "Корякский автономный округ", 87 },
                    { 92, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8241), "Камчатская область", 87 },
                    { 91, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8240), "Амурская край", 87 },
                    { 90, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8239), "Хабаровский край", 87 },
                    { 89, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8238), "Приморский край", 87 },
                    { 88, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8237), "Республика Саха (Якутия)", 87 },
                    { 86, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8236), "в том числе Агинский Бурятский автономный округ", 70 },
                    { 85, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8235), "Читинская область", 70 },
                    { 84, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8234), "Томская область", 70 },
                    { 83, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8233), "Омская область", 70 },
                    { 82, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8232), "Новосибирская область", 70 },
                    { 81, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8231), "Кемеровская область", 70 },
                    { 80, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8230), "в том числе Усть-Ордынский Бурятский автономный округ", 70 },
                    { 79, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8229), "Иркутская область", 70 }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CreatedAt", "Name", "ParentRegionId" },
                values: new object[,]
                {
                    { 78, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8228), "Эвенкийский автономный округ", 70 },
                    { 77, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8227), "в том числе Таймырский (Долгано-Ненецкий) автономный округ", 70 },
                    { 76, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8226), "Красноярский край", 70 },
                    { 74, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8224), "Республика Хакасия", 70 },
                    { 50, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8202), "Республика Мордовия", 47 },
                    { 48, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8200), "Республика Башкортостан", 47 },
                    { 96, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8245), "Еврейская автономная область", 87 },
                    { 22, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8175), "Республика Карелия", 21 },
                    { 20, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8173), "г. Москва", 2 },
                    { 19, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8172), "Ярославская область", 2 },
                    { 18, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8172), "Тульская область", 2 },
                    { 17, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8170), "Тверская область", 2 },
                    { 16, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8169), "Тамбовская область", 2 },
                    { 15, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8168), "Смоленская область", 2 },
                    { 14, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8167), "Рязанская область", 2 },
                    { 13, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8167), "Орловская область", 2 },
                    { 12, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8165), "Московская область", 2 },
                    { 11, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8121), "Липецкая область", 2 },
                    { 10, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8120), "Курская область", 2 },
                    { 9, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8119), "Костромская область", 2 },
                    { 8, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8119), "Калужская область", 2 },
                    { 7, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8118), "Ивановская область", 2 },
                    { 6, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8117), "Воронежская область", 2 },
                    { 5, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8116), "Владимирская область", 2 },
                    { 4, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8115), "Брянская область", 2 },
                    { 3, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8114), "Белгородская область", 2 },
                    { 23, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8176), "Республика Коми", 21 },
                    { 49, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8201), "Республика Марий Эл", 47 },
                    { 24, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8177), "Архангельская область", 21 },
                    { 26, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8179), "Вологодская область", 21 },
                    { 46, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8198), "Ростовская область", 33 },
                    { 45, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8197), "Волгоградская область", 33 },
                    { 44, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8196), "Астраханская область", 33 },
                    { 43, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8195), "Ставропольский край", 33 },
                    { 42, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8194), "Краснодарский край", 33 },
                    { 41, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8193), "Чеченская Республика", 33 },
                    { 40, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8192), "Республика Северная Осетия - Алания", 33 },
                    { 39, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8191), "Карачаево-Черкесская Республика", 33 },
                    { 38, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8191), "Республика Калмыкия", 33 },
                    { 37, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8190), "Кабардино-Балкарская Республика", 33 },
                    { 36, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8189), "Республика Ингушетия", 33 },
                    { 35, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8188), "Республика Дагестан", 33 }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CreatedAt", "Name", "ParentRegionId" },
                values: new object[,]
                {
                    { 34, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8187), "Республика Адыгея", 33 },
                    { 32, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8185), "г. Санкт-Петербург", 21 },
                    { 31, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8184), "Псковская область", 21 },
                    { 30, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8183), "Новгородская область", 21 },
                    { 29, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8182), "Мурманская область", 21 },
                    { 28, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8181), "Ленинградская область", 21 },
                    { 27, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8180), "Калининградская область", 21 },
                    { 25, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8178), "в том числе Ненецкий автономный округ", 21 },
                    { 97, new DateTime(2021, 11, 17, 23, 35, 37, 624, DateTimeKind.Utc).AddTicks(8246), "Чукотский автономный округ", 87 }
                });

            migrationBuilder.InsertData(
                table: "Advertisements",
                columns: new[] { "Id", "Address", "Body", "CategoryId", "CreatedAt", "IsDeleted", "OwnerId", "Price", "RegionId", "Status", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 3, "299713 г. Керчь, ул. Куприна, 3", "Телевизор Xiaomi Mi TV 4S 50, 50, Ultra HD 4K", 10, new DateTime(2021, 11, 17, 23, 35, 37, 608, DateTimeKind.Utc).AddTicks(380), false, "c191e5f8-bf5b-40a9-9ab6-4d08704e373b", 40000m, 3, 0, "Телевизор", null },
                    { 7, "299713 г. Керчь, ул. Куприна, 3", "Магнитофон (от магнит и греч. φωνή звук) — электромеханическое устройство, предназначенное для записи звуковой информации на магнитные носители и/или её воспроизведения. В качестве носителя используются материалы с магнитными свойствами: магнитная лента, проволока, магнитные манжеты, диски, барабаны и т. д.", 10, new DateTime(2021, 11, 17, 23, 35, 37, 608, DateTimeKind.Utc).AddTicks(390), false, "c191e5f8-bf5b-40a9-9ab6-4d08704e373b", 2000m, 8, 0, "Куплю магнитофон", null },
                    { 19, "299713 г. Керчь, ул. Куприна, 3", "Видеомагнитофо́н — устройство для записи телевизионного сигнала на магнитную ленту и его последующего воспроизведения[1][2]. От магнитофона отличается многократно увеличенной полосой записываемых частот и устройством лентопротяжного механизма[3]. Получаемая при помощи видеомагнитофона запись изображения и звука называется видеофонограммой[4][5]. Возможность записи высокочастотных и импульсных сигналов делает видеомагнитофон пригодным не только для видеозаписи, но и для других прикладных задач, связанных с регистрацией информации.", 10, new DateTime(2021, 11, 17, 23, 35, 37, 608, DateTimeKind.Utc).AddTicks(456), false, "c191e5f8-bf5b-40a9-9ab6-4d08704e373b", 40000m, 7, 0, "Видеомагнитофон", null },
                    { 14, "299812 г. Судак, ул. Сергеева, 2", "Видеомагнитофо́н — устройство для записи телевизионного сигнала на магнитную ленту и его последующего воспроизведения[1][2]. От магнитофона отличается многократно увеличенной полосой записываемых частот и устройством лентопротяжного механизма[3]. Получаемая при помощи видеомагнитофона запись изображения и звука называется видеофонограммой[4][5]. Возможность записи высокочастотных и импульсных сигналов делает видеомагнитофон пригодным не только для видеозаписи, но и для других прикладных задач, связанных с регистрацией информации.", 10, new DateTime(2021, 11, 17, 23, 35, 37, 608, DateTimeKind.Utc).AddTicks(404), false, "54b1ff98-6b5f-4c5e-97a9-747095e1f5dc", 40000m, 7, 0, "Видеомагнитофон", null },
                    { 6, "299812 г. Судак, ул. Сергеева, 2", "Видеомагнитофо́н — устройство для записи телевизионного сигнала на магнитную ленту и его последующего воспроизведения[1][2]. От магнитофона отличается многократно увеличенной полосой записываемых частот и устройством лентопротяжного механизма[3]. Получаемая при помощи видеомагнитофона запись изображения и звука называется видеофонограммой[4][5]. Возможность записи высокочастотных и импульсных сигналов делает видеомагнитофон пригодным не только для видеозаписи, но и для других прикладных задач, связанных с регистрацией информации.", 10, new DateTime(2021, 11, 17, 23, 35, 37, 608, DateTimeKind.Utc).AddTicks(388), false, "54b1ff98-6b5f-4c5e-97a9-747095e1f5dc", 40000m, 7, 0, "Видеомагнитофон", null },
                    { 21, "299411 г. Москва, ул. Тургенева, 1", "Примитивные стиральные машины представляли собой деревянный ящик с подвижной рамой. Первая стиральная машина, запущенная в серийное производство, была создана в 1907 году[источник не указан 109 дней] Уильямом Блекстоуном, у неё был ручной привод (есть также мнение, что первую сделал Натаниэл Бриггс (Nathaniel Briggs)). В Европе первые стиральные машины начали производить в Германии в 1900 г. Современные машины с электрическим приводом появились в 1904 году[1]. Механизация труда практически привела к исчезновению профессии прачки. В 1949 году в США появилась первая автоматическая стиральная машина.", 9, new DateTime(2021, 11, 17, 23, 35, 37, 608, DateTimeKind.Utc).AddTicks(459), false, "64dbb199-0a95-4f1a-afcf-10cc827fd3c8", 2000m, 6, 0, "Стиральная машина", null },
                    { 16, "299314 г. Симферополь, ул. Чернышевского, 4", "Примитивные стиральные машины представляли собой деревянный ящик с подвижной рамой. Первая стиральная машина, запущенная в серийное производство, была создана в 1907 году[источник не указан 109 дней] Уильямом Блекстоуном, у неё был ручной привод (есть также мнение, что первую сделал Натаниэл Бриггс (Nathaniel Briggs)). В Европе первые стиральные машины начали производить в Германии в 1900 г. Современные машины с электрическим приводом появились в 1904 году[1]. Механизация труда практически привела к исчезновению профессии прачки. В 1949 году в США появилась первая автоматическая стиральная машина.", 9, new DateTime(2021, 11, 17, 23, 35, 37, 608, DateTimeKind.Utc).AddTicks(407), false, "09c529c8-e798-44ac-9eac-e0150182fa4c", 2000m, 6, 0, "Стиральная машина", null },
                    { 15, "299713 г. Керчь, ул. Куприна, 3", "Магнитофон (от магнит и греч. φωνή звук) — электромеханическое устройство, предназначенное для записи звуковой информации на магнитные носители и/или её воспроизведения. В качестве носителя используются материалы с магнитными свойствами: магнитная лента, проволока, магнитные манжеты, диски, барабаны и т. д.", 10, new DateTime(2021, 11, 17, 23, 35, 37, 608, DateTimeKind.Utc).AddTicks(406), false, "c191e5f8-bf5b-40a9-9ab6-4d08704e373b", 2000m, 8, 0, "Куплю магнитофон", null },
                    { 8, "299314 г. Симферополь, ул. Чернышевского, 4", "Примитивные стиральные машины представляли собой деревянный ящик с подвижной рамой. Первая стиральная машина, запущенная в серийное производство, была создана в 1907 году[источник не указан 109 дней] Уильямом Блекстоуном, у неё был ручной привод (есть также мнение, что первую сделал Натаниэл Бриггс (Nathaniel Briggs)). В Европе первые стиральные машины начали производить в Германии в 1900 г. Современные машины с электрическим приводом появились в 1904 году[1]. Механизация труда практически привела к исчезновению профессии прачки. В 1949 году в США появилась первая автоматическая стиральная машина.", 9, new DateTime(2021, 11, 17, 23, 35, 37, 608, DateTimeKind.Utc).AddTicks(391), false, "09c529c8-e798-44ac-9eac-e0150182fa4c", 2000m, 6, 0, "Стиральная машина", null },
                    { 13, "299415 г. Ялта, ул. Достоевского, 5", "Примитивные стиральные машины представляли собой деревянный ящик с подвижной рамой. Первая стиральная машина, запущенная в серийное производство, была создана в 1907 году[источник не указан 109 дней] Уильямом Блекстоуном, у неё был ручной привод (есть также мнение, что первую сделал Натаниэл Бриггс (Nathaniel Briggs)). В Европе первые стиральные машины начали производить в Германии в 1900 г. Современные машины с электрическим приводом появились в 1904 году[1]. Механизация труда практически привела к исчезновению профессии прачки. В 1949 году в США появилась первая автоматическая стиральная машина.", 9, new DateTime(2021, 11, 17, 23, 35, 37, 608, DateTimeKind.Utc).AddTicks(402), false, "7e24ccd2-34fd-4289-9a78-1aae93623bae", 10000m, 5, 0, "Стиральная машина", null },
                    { 5, "299415 г. Ялта, ул. Достоевского, 5", "Примитивные стиральные машины представляли собой деревянный ящик с подвижной рамой. Первая стиральная машина, запущенная в серийное производство, была создана в 1907 году[источник не указан 109 дней] Уильямом Блекстоуном, у неё был ручной привод (есть также мнение, что первую сделал Натаниэл Бриггс (Nathaniel Briggs)). В Европе первые стиральные машины начали производить в Германии в 1900 г. Современные машины с электрическим приводом появились в 1904 году[1]. Механизация труда практически привела к исчезновению профессии прачки. В 1949 году в США появилась первая автоматическая стиральная машина.", 9, new DateTime(2021, 11, 17, 23, 35, 37, 608, DateTimeKind.Utc).AddTicks(386), false, "7e24ccd2-34fd-4289-9a78-1aae93623bae", 10000m, 5, 0, "Стиральная машина", null },
                    { 17, "299314 г. Симферополь, ул. Чернышевского, 4", "Магнитофон (от магнит и греч. φωνή звук) — электромеханическое устройство, предназначенное для записи звуковой информации на магнитные носители и/или её воспроизведения. В качестве носителя используются материалы с магнитными свойствами: магнитная лента, проволока, магнитные манжеты, диски, барабаны и т. д.", 10, new DateTime(2021, 11, 17, 23, 35, 37, 608, DateTimeKind.Utc).AddTicks(453), false, "09c529c8-e798-44ac-9eac-e0150182fa4c", 2000m, 4, 0, "Магнитофон", null },
                    { 12, "299314 г. Симферополь, ул. Чернышевского, 4", "Магнитофон (от магнит и греч. φωνή звук) — электромеханическое устройство, предназначенное для записи звуковой информации на магнитные носители и/или её воспроизведения. В качестве носителя используются материалы с магнитными свойствами: магнитная лента, проволока, магнитные манжеты, диски, барабаны и т. д.", 10, new DateTime(2021, 11, 17, 23, 35, 37, 608, DateTimeKind.Utc).AddTicks(399), false, "09c529c8-e798-44ac-9eac-e0150182fa4c", 2000m, 4, 0, "Магнитофон", null },
                    { 4, "299314 г. Симферополь, ул. Чернышевского, 4", "Магнитофон (от магнит и греч. φωνή звук) — электромеханическое устройство, предназначенное для записи звуковой информации на магнитные носители и/или её воспроизведения. В качестве носителя используются материалы с магнитными свойствами: магнитная лента, проволока, магнитные манжеты, диски, барабаны и т. д.", 10, new DateTime(2021, 11, 17, 23, 35, 37, 608, DateTimeKind.Utc).AddTicks(384), false, "09c529c8-e798-44ac-9eac-e0150182fa4c", 2000m, 4, 0, "Магнитофон", null },
                    { 11, "299713 г. Керчь, ул. Куприна, 3", "Телевизор Xiaomi Mi TV 4S 50, 50, Ultra HD 4K", 10, new DateTime(2021, 11, 17, 23, 35, 37, 608, DateTimeKind.Utc).AddTicks(398), false, "c191e5f8-bf5b-40a9-9ab6-4d08704e373b", 40000m, 3, 0, "Телевизор", null },
                    { 18, "299314 г. Симферополь, ул. Чернышевского, 4", "Примитивные стиральные машины представляли собой деревянный ящик с подвижной рамой. Первая стиральная машина, запущенная в серийное производство, была создана в 1907 году[источник не указан 109 дней] Уильямом Блекстоуном, у неё был ручной привод (есть также мнение, что первую сделал Натаниэл Бриггс (Nathaniel Briggs)). В Европе первые стиральные машины начали производить в Германии в 1900 г. Современные машины с электрическим приводом появились в 1904 году[1]. Механизация труда практически привела к исчезновению профессии прачки. В 1949 году в США появилась первая автоматическая стиральная машина.", 9, new DateTime(2021, 11, 17, 23, 35, 37, 608, DateTimeKind.Utc).AddTicks(455), false, "09c529c8-e798-44ac-9eac-e0150182fa4c", 10000m, 5, 0, "Стиральная машина", null },
                    { 20, "299812 г. Судак, ул. Сергеева, 2", "Магнитофон (от магнит и греч. φωνή звук) — электромеханическое устройство, предназначенное для записи звуковой информации на магнитные носители и/или её воспроизведения. В качестве носителя используются материалы с магнитными свойствами: магнитная лента, проволока, магнитные манжеты, диски, барабаны и т. д.", 10, new DateTime(2021, 11, 17, 23, 35, 37, 608, DateTimeKind.Utc).AddTicks(457), false, "54b1ff98-6b5f-4c5e-97a9-747095e1f5dc", 2000m, 8, 0, "Куплю магнитофон", null }
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
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 21);

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
                keyValue: 10);

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
