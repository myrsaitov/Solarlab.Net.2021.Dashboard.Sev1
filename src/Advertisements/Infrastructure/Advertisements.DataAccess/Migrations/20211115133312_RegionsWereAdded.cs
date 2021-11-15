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
                    { 1, new DateTime(2021, 11, 15, 13, 33, 12, 439, DateTimeKind.Utc).AddTicks(1794), false, "Транспорт", null, null },
                    { 5, new DateTime(2021, 11, 15, 13, 33, 12, 439, DateTimeKind.Utc).AddTicks(3413), false, "Недвижимость", null, null },
                    { 9, new DateTime(2021, 11, 15, 13, 33, 12, 439, DateTimeKind.Utc).AddTicks(3879), false, "Электроника", null, null }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CreatedAt", "Name", "ParentRegionId" },
                values: new object[] { 1, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(5702), "Российская Федерация", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "ParentCategoryId", "UpdatedAt" },
                values: new object[,]
                {
                    { 2, new DateTime(2021, 11, 15, 13, 33, 12, 439, DateTimeKind.Utc).AddTicks(2721), false, "Автомобили", 1, null },
                    { 17, new DateTime(2021, 11, 15, 13, 33, 12, 439, DateTimeKind.Utc).AddTicks(3889), false, "Фототехника", 9, null },
                    { 16, new DateTime(2021, 11, 15, 13, 33, 12, 439, DateTimeKind.Utc).AddTicks(3887), false, "Товары для компьютера", 9, null },
                    { 14, new DateTime(2021, 11, 15, 13, 33, 12, 439, DateTimeKind.Utc).AddTicks(3885), false, "Планшеты и электронные книги", 9, null },
                    { 13, new DateTime(2021, 11, 15, 13, 33, 12, 439, DateTimeKind.Utc).AddTicks(3884), false, "Ноутбуки", 9, null },
                    { 12, new DateTime(2021, 11, 15, 13, 33, 12, 439, DateTimeKind.Utc).AddTicks(3883), false, "Настольные компьютеры", 9, null },
                    { 11, new DateTime(2021, 11, 15, 13, 33, 12, 439, DateTimeKind.Utc).AddTicks(3882), false, "Игры, приставки и программы", 9, null },
                    { 15, new DateTime(2021, 11, 15, 13, 33, 12, 439, DateTimeKind.Utc).AddTicks(3886), false, "Телефоны", 9, null },
                    { 8, new DateTime(2021, 11, 15, 13, 33, 12, 439, DateTimeKind.Utc).AddTicks(3878), false, "Дома, дачи, коттеджи", 5, null },
                    { 7, new DateTime(2021, 11, 15, 13, 33, 12, 439, DateTimeKind.Utc).AddTicks(3877), false, "Комнаты", 5, null },
                    { 6, new DateTime(2021, 11, 15, 13, 33, 12, 439, DateTimeKind.Utc).AddTicks(3874), false, "Квартиры", 5, null },
                    { 4, new DateTime(2021, 11, 15, 13, 33, 12, 439, DateTimeKind.Utc).AddTicks(3411), false, "Грузовики и спецтехника", 1, null },
                    { 3, new DateTime(2021, 11, 15, 13, 33, 12, 439, DateTimeKind.Utc).AddTicks(3409), false, "Мотоциклы и мототехника", 1, null },
                    { 10, new DateTime(2021, 11, 15, 13, 33, 12, 439, DateTimeKind.Utc).AddTicks(3881), false, "Аудио и видео", 9, null }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CreatedAt", "Name", "ParentRegionId" },
                values: new object[,]
                {
                    { 98, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6283), "Севастополь", 1 },
                    { 2, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6178), "Центральный федеральный округ", 1 },
                    { 21, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6201), "Северо-Западный федеральный округ", 1 },
                    { 33, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6213), "Южный федеральный округ", 1 },
                    { 47, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6229), "Приволжский федеральный округ", 1 },
                    { 63, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6246), "Уральский федеральный округ", 1 },
                    { 70, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6253), "Сибирский федеральный округ", 1 },
                    { 87, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6271), "Дальневосточный федеральный округ", 1 },
                    { 99, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6284), "Крым", 1 }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CreatedAt", "Name", "ParentRegionId" },
                values: new object[,]
                {
                    { 3, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6181), "Белгородская область", 2 },
                    { 71, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6255), "Республика Алтай", 70 },
                    { 69, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6252), "в том числе Челябинская область", 63 },
                    { 68, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6251), "в том числе Ямало-Ненецкий автономный округ", 63 },
                    { 67, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6250), "в том числе Ханты-Мансийский автономный округ - Югра", 63 },
                    { 66, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6249), "Тюменская область", 63 },
                    { 65, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6248), "Свердловская область", 63 },
                    { 64, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6247), "Курганская область", 63 },
                    { 62, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6245), "Ульяновская область", 47 },
                    { 72, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6256), "Республика Бурятия", 70 },
                    { 61, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6244), "Саратовская область", 47 },
                    { 59, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6242), "в том числе Коми-Пермяцкий автономный округ", 47 },
                    { 58, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6241), "Пермская область", 47 },
                    { 57, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6240), "Пензенская область", 47 },
                    { 56, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6239), "Оренбургская область", 47 },
                    { 55, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6238), "Нижегородская область", 47 },
                    { 54, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6236), "Кировская область", 47 },
                    { 53, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6235), "Чувашская Республика", 47 },
                    { 52, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6234), "Удмуртская Республика", 47 },
                    { 60, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6243), "Самарская область", 47 },
                    { 73, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6257), "Республика Тыва", 70 },
                    { 74, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6258), "Республика Хакасия", 70 },
                    { 75, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6259), "Алтайский край", 70 },
                    { 95, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6280), "Сахалинская область", 87 },
                    { 94, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6279), "Магаданская область", 87 },
                    { 93, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6277), "Корякский автономный округ", 87 },
                    { 92, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6276), "Камчатская область", 87 },
                    { 91, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6275), "Амурская край", 87 },
                    { 90, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6274), "Хабаровский край", 87 },
                    { 89, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6273), "Приморский край", 87 },
                    { 88, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6272), "Республика Саха (Якутия)", 87 },
                    { 86, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6270), "в том числе Агинский Бурятский автономный округ", 70 },
                    { 85, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6269), "Читинская область", 70 },
                    { 84, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6268), "Томская область", 70 },
                    { 83, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6267), "Омская область", 70 },
                    { 82, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6266), "Новосибирская область", 70 },
                    { 81, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6265), "Кемеровская область", 70 },
                    { 80, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6264), "в том числе Усть-Ордынский Бурятский автономный округ", 70 },
                    { 79, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6263), "Иркутская область", 70 },
                    { 78, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6262), "Эвенкийский автономный округ", 70 },
                    { 77, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6261), "в том числе Таймырский (Долгано-Ненецкий) автономный округ", 70 },
                    { 76, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6260), "Красноярский край", 70 }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CreatedAt", "Name", "ParentRegionId" },
                values: new object[,]
                {
                    { 51, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6233), "Республика Татарстан", 47 },
                    { 96, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6281), "Еврейская автономная область", 87 },
                    { 50, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6232), "Республика Мордовия", 47 },
                    { 48, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6230), "Республика Башкортостан", 47 },
                    { 22, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6202), "Республика Карелия", 21 },
                    { 20, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6199), "г. Москва", 2 },
                    { 19, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6198), "Ярославская область", 2 },
                    { 18, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6197), "Тульская область", 2 },
                    { 17, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6196), "Тверская область", 2 },
                    { 16, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6195), "Тамбовская область", 2 },
                    { 15, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6194), "Смоленская область", 2 },
                    { 14, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6193), "Рязанская область", 2 },
                    { 23, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6203), "Республика Коми", 21 },
                    { 13, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6192), "Орловская область", 2 },
                    { 11, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6190), "Липецкая область", 2 },
                    { 10, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6189), "Курская область", 2 },
                    { 9, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6188), "Костромская область", 2 },
                    { 8, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6187), "Калужская область", 2 },
                    { 7, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6186), "Ивановская область", 2 },
                    { 6, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6184), "Воронежская область", 2 },
                    { 5, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6183), "Владимирская область", 2 },
                    { 4, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6182), "Брянская область", 2 },
                    { 12, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6191), "Московская область", 2 },
                    { 24, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6204), "Архангельская область", 21 },
                    { 25, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6205), "в том числе Ненецкий автономный округ", 21 },
                    { 26, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6206), "Вологодская область", 21 },
                    { 46, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6228), "Ростовская область", 33 },
                    { 45, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6227), "Волгоградская область", 33 },
                    { 44, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6226), "Астраханская область", 33 },
                    { 43, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6225), "Ставропольский край", 33 },
                    { 42, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6224), "Краснодарский край", 33 },
                    { 41, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6223), "Чеченская Республика", 33 },
                    { 40, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6221), "Республика Северная Осетия - Алания", 33 },
                    { 39, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6220), "Карачаево-Черкесская Республика", 33 },
                    { 38, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6219), "Республика Калмыкия", 33 },
                    { 37, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6218), "Кабардино-Балкарская Республика", 33 },
                    { 36, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6217), "Республика Ингушетия", 33 },
                    { 35, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6215), "Республика Дагестан", 33 },
                    { 34, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6214), "Республика Адыгея", 33 },
                    { 32, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6212), "г. Санкт-Петербург", 21 },
                    { 31, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6211), "Псковская область", 21 },
                    { 30, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6210), "Новгородская область", 21 }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CreatedAt", "Name", "ParentRegionId" },
                values: new object[,]
                {
                    { 29, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6209), "Мурманская область", 21 },
                    { 28, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6208), "Ленинградская область", 21 },
                    { 27, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6207), "Калининградская область", 21 },
                    { 49, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6231), "Республика Марий Эл", 47 },
                    { 97, new DateTime(2021, 11, 15, 13, 33, 12, 445, DateTimeKind.Utc).AddTicks(6282), "Чукотский автономный округ", 87 }
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
