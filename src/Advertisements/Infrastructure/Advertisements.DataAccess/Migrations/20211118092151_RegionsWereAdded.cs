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
                    { 1, new DateTime(2021, 11, 18, 9, 21, 51, 148, DateTimeKind.Utc).AddTicks(6653), false, "Транспорт", null, null },
                    { 5, new DateTime(2021, 11, 18, 9, 21, 51, 148, DateTimeKind.Utc).AddTicks(7561), false, "Недвижимость", null, null },
                    { 9, new DateTime(2021, 11, 18, 9, 21, 51, 148, DateTimeKind.Utc).AddTicks(7971), false, "Электроника", null, null }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CreatedAt", "Name", "ParentRegionId" },
                values: new object[] { 1, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9297), "Российская Федерация", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "ParentCategoryId", "UpdatedAt" },
                values: new object[,]
                {
                    { 2, new DateTime(2021, 11, 18, 9, 21, 51, 148, DateTimeKind.Utc).AddTicks(7134), false, "Автомобили", 1, null },
                    { 17, new DateTime(2021, 11, 18, 9, 21, 51, 148, DateTimeKind.Utc).AddTicks(7980), false, "Фототехника", 9, null },
                    { 16, new DateTime(2021, 11, 18, 9, 21, 51, 148, DateTimeKind.Utc).AddTicks(7979), false, "Товары для компьютера", 9, null },
                    { 14, new DateTime(2021, 11, 18, 9, 21, 51, 148, DateTimeKind.Utc).AddTicks(7977), false, "Планшеты и электронные книги", 9, null },
                    { 13, new DateTime(2021, 11, 18, 9, 21, 51, 148, DateTimeKind.Utc).AddTicks(7976), false, "Ноутбуки", 9, null },
                    { 12, new DateTime(2021, 11, 18, 9, 21, 51, 148, DateTimeKind.Utc).AddTicks(7975), false, "Настольные компьютеры", 9, null },
                    { 11, new DateTime(2021, 11, 18, 9, 21, 51, 148, DateTimeKind.Utc).AddTicks(7974), false, "Игры, приставки и программы", 9, null },
                    { 15, new DateTime(2021, 11, 18, 9, 21, 51, 148, DateTimeKind.Utc).AddTicks(7978), false, "Телефоны", 9, null },
                    { 8, new DateTime(2021, 11, 18, 9, 21, 51, 148, DateTimeKind.Utc).AddTicks(7970), false, "Дома, дачи, коттеджи", 5, null },
                    { 7, new DateTime(2021, 11, 18, 9, 21, 51, 148, DateTimeKind.Utc).AddTicks(7969), false, "Комнаты", 5, null },
                    { 6, new DateTime(2021, 11, 18, 9, 21, 51, 148, DateTimeKind.Utc).AddTicks(7966), false, "Квартиры", 5, null },
                    { 4, new DateTime(2021, 11, 18, 9, 21, 51, 148, DateTimeKind.Utc).AddTicks(7559), false, "Грузовики и спецтехника", 1, null },
                    { 3, new DateTime(2021, 11, 18, 9, 21, 51, 148, DateTimeKind.Utc).AddTicks(7557), false, "Мотоциклы и мототехника", 1, null },
                    { 10, new DateTime(2021, 11, 18, 9, 21, 51, 148, DateTimeKind.Utc).AddTicks(7972), false, "Аудио и видео", 9, null }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CreatedAt", "Name", "ParentRegionId" },
                values: new object[,]
                {
                    { 98, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9880), "Севастополь", 1 },
                    { 2, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9744), "Центральный федеральный округ", 1 },
                    { 21, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9766), "Северо-Западный федеральный округ", 1 },
                    { 33, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9779), "Южный федеральный округ", 1 },
                    { 47, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9795), "Приволжский федеральный округ", 1 },
                    { 63, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9811), "Уральский федеральный округ", 1 },
                    { 70, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9851), "Сибирский федеральный округ", 1 },
                    { 87, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9869), "Дальневосточный федеральный округ", 1 },
                    { 99, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9881), "Крым", 1 }
                });

            migrationBuilder.InsertData(
                table: "Advertisements",
                columns: new[] { "Id", "Address", "Body", "CategoryId", "CreatedAt", "IsDeleted", "OwnerId", "Price", "RegionId", "Status", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "299411 г. Москва, ул. Тургенева, 1", "Телевизор Xiaomi Mi TV 4S 50, 50, Ultra HD 4K", 10, new DateTime(2021, 11, 18, 9, 21, 51, 132, DateTimeKind.Utc).AddTicks(5983), false, "64dbb199-0a95-4f1a-afcf-10cc827fd3c8", 40000m, 1, 0, "Продам телевизор", null },
                    { 2, "299812 г. Судак, ул. Сергеева, 2", "Телевизор Xiaomi Mi TV 4S 50, 50, Ultra HD 4K", 10, new DateTime(2021, 11, 18, 9, 21, 51, 132, DateTimeKind.Utc).AddTicks(6447), false, "54b1ff98-6b5f-4c5e-97a9-747095e1f5dc", 40000m, 2, 0, "Продам телевизор", null }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CreatedAt", "Name", "ParentRegionId" },
                values: new object[,]
                {
                    { 71, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9852), "Республика Алтай", 70 },
                    { 69, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9850), "в том числе Челябинская область", 63 },
                    { 68, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9849), "в том числе Ямало-Ненецкий автономный округ", 63 },
                    { 67, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9815), "в том числе Ханты-Мансийский автономный округ - Югра", 63 },
                    { 66, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9814), "Тюменская область", 63 },
                    { 65, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9813), "Свердловская область", 63 },
                    { 64, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9812), "Курганская область", 63 },
                    { 62, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9810), "Ульяновская область", 47 },
                    { 61, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9809), "Саратовская область", 47 },
                    { 60, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9808), "Самарская область", 47 },
                    { 59, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9807), "в том числе Коми-Пермяцкий автономный округ", 47 },
                    { 58, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9806), "Пермская область", 47 },
                    { 57, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9805), "Пензенская область", 47 },
                    { 56, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9804), "Оренбургская область", 47 },
                    { 55, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9803), "Нижегородская область", 47 },
                    { 54, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9802), "Кировская область", 47 },
                    { 53, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9801), "Чувашская Республика", 47 },
                    { 52, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9800), "Удмуртская Республика", 47 },
                    { 72, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9853), "Республика Бурятия", 70 },
                    { 73, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9854), "Республика Тыва", 70 },
                    { 74, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9855), "Республика Хакасия", 70 },
                    { 75, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9857), "Алтайский край", 70 },
                    { 95, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9877), "Сахалинская область", 87 },
                    { 94, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9876), "Магаданская область", 87 },
                    { 93, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9875), "Корякский автономный округ", 87 },
                    { 92, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9874), "Камчатская область", 87 },
                    { 91, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9873), "Амурская край", 87 },
                    { 90, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9872), "Хабаровский край", 87 },
                    { 89, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9871), "Приморский край", 87 },
                    { 88, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9870), "Республика Саха (Якутия)", 87 },
                    { 86, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9868), "в том числе Агинский Бурятский автономный округ", 70 },
                    { 85, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9867), "Читинская область", 70 },
                    { 84, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9866), "Томская область", 70 },
                    { 83, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9865), "Омская область", 70 },
                    { 82, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9864), "Новосибирская область", 70 },
                    { 81, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9863), "Кемеровская область", 70 },
                    { 80, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9862), "в том числе Усть-Ордынский Бурятский автономный округ", 70 },
                    { 79, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9861), "Иркутская область", 70 },
                    { 78, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9860), "Эвенкийский автономный округ", 70 },
                    { 77, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9859), "в том числе Таймырский (Долгано-Ненецкий) автономный округ", 70 }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CreatedAt", "Name", "ParentRegionId" },
                values: new object[,]
                {
                    { 76, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9858), "Красноярский край", 70 },
                    { 51, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9799), "Республика Татарстан", 47 },
                    { 50, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9798), "Республика Мордовия", 47 },
                    { 49, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9797), "Республика Марий Эл", 47 },
                    { 48, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9796), "Республика Башкортостан", 47 },
                    { 22, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9767), "Республика Карелия", 21 },
                    { 20, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9765), "г. Москва", 2 },
                    { 19, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9764), "Ярославская область", 2 },
                    { 18, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9763), "Тульская область", 2 },
                    { 17, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9762), "Тверская область", 2 },
                    { 16, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9761), "Тамбовская область", 2 },
                    { 15, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9760), "Смоленская область", 2 },
                    { 14, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9759), "Рязанская область", 2 },
                    { 13, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9757), "Орловская область", 2 },
                    { 12, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9756), "Московская область", 2 },
                    { 11, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9755), "Липецкая область", 2 },
                    { 10, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9754), "Курская область", 2 },
                    { 9, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9753), "Костромская область", 2 },
                    { 8, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9752), "Калужская область", 2 },
                    { 7, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9751), "Ивановская область", 2 },
                    { 6, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9750), "Воронежская область", 2 },
                    { 5, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9749), "Владимирская область", 2 },
                    { 4, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9747), "Брянская область", 2 },
                    { 3, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9746), "Белгородская область", 2 },
                    { 23, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9768), "Республика Коми", 21 },
                    { 96, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9878), "Еврейская автономная область", 87 },
                    { 24, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9769), "Архангельская область", 21 },
                    { 26, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9772), "Вологодская область", 21 },
                    { 46, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9794), "Ростовская область", 33 },
                    { 45, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9793), "Волгоградская область", 33 },
                    { 44, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9791), "Астраханская область", 33 },
                    { 43, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9790), "Ставропольский край", 33 },
                    { 42, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9789), "Краснодарский край", 33 },
                    { 41, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9788), "Чеченская Республика", 33 },
                    { 40, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9787), "Республика Северная Осетия - Алания", 33 },
                    { 39, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9786), "Карачаево-Черкесская Республика", 33 },
                    { 38, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9785), "Республика Калмыкия", 33 },
                    { 37, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9783), "Кабардино-Балкарская Республика", 33 },
                    { 36, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9782), "Республика Ингушетия", 33 },
                    { 35, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9781), "Республика Дагестан", 33 },
                    { 34, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9780), "Республика Адыгея", 33 },
                    { 32, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9778), "г. Санкт-Петербург", 21 }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CreatedAt", "Name", "ParentRegionId" },
                values: new object[,]
                {
                    { 31, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9777), "Псковская область", 21 },
                    { 30, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9776), "Новгородская область", 21 },
                    { 29, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9775), "Мурманская область", 21 },
                    { 28, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9774), "Ленинградская область", 21 },
                    { 27, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9773), "Калининградская область", 21 },
                    { 25, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9770), "в том числе Ненецкий автономный округ", 21 },
                    { 97, new DateTime(2021, 11, 18, 9, 21, 51, 153, DateTimeKind.Utc).AddTicks(9879), "Чукотский автономный округ", 87 }
                });

            migrationBuilder.InsertData(
                table: "Advertisements",
                columns: new[] { "Id", "Address", "Body", "CategoryId", "CreatedAt", "IsDeleted", "OwnerId", "Price", "RegionId", "Status", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 3, "293713 г. Керчь, ул. Куприна, 3", "Телевизор Xiaomi Mi TV 4S 50, 50, Ultra HD 4K", 10, new DateTime(2021, 11, 18, 9, 21, 51, 132, DateTimeKind.Utc).AddTicks(6450), false, "c191e5f8-bf5b-40a9-9ab6-4d08704e373b", 40000m, 3, 0, "Продам телевизор", null },
                    { 18, "298413 г. Джанкой, ул. Куприна, 3", "Телевизор Xiaomi Mi TV 4S 50, 50, Ultra HD 4K", 10, new DateTime(2021, 11, 18, 9, 21, 51, 132, DateTimeKind.Utc).AddTicks(6469), false, "c191e5f8-bf5b-40a9-9ab6-4d08704e373b", 40000m, 18, 0, "Продам телевизор", null },
                    { 17, "297812 г. Астрахань, ул. Сергеева, 2", "Телевизор Xiaomi Mi TV 4S 50, 50, Ultra HD 4K", 10, new DateTime(2021, 11, 18, 9, 21, 51, 132, DateTimeKind.Utc).AddTicks(6468), false, "54b1ff98-6b5f-4c5e-97a9-747095e1f5dc", 40000m, 17, 0, "Продам телевизор", null },
                    { 16, "299411 г. Казань, ул. Тургенева, 1", "Телевизор Xiaomi Mi TV 4S 50, 50, Ultra HD 4K", 10, new DateTime(2021, 11, 18, 9, 21, 51, 132, DateTimeKind.Utc).AddTicks(6466), false, "64dbb199-0a95-4f1a-afcf-10cc827fd3c8", 40000m, 16, 0, "Продам телевизор", null },
                    { 15, "292415 г. Ялта, ул. Достоевского, 5", "Телевизор Xiaomi Mi TV 4S 50, 50, Ultra HD 4K", 10, new DateTime(2021, 11, 18, 9, 21, 51, 132, DateTimeKind.Utc).AddTicks(6465), false, "7e24ccd2-34fd-4289-9a78-1aae93623bae", 40000m, 15, 0, "Продам телевизор", null },
                    { 14, "295314 г. Симферополь, ул. Чернышевского, 4", "Телевизор Xiaomi Mi TV 4S 50, 50, Ultra HD 4K", 10, new DateTime(2021, 11, 18, 9, 21, 51, 132, DateTimeKind.Utc).AddTicks(6464), false, "09c529c8-e798-44ac-9eac-e0150182fa4c", 40000m, 14, 0, "Продам телевизор", null },
                    { 13, "293713 г. Керчь, ул. Куприна, 3", "Телевизор Xiaomi Mi TV 4S 50, 50, Ultra HD 4K", 10, new DateTime(2021, 11, 18, 9, 21, 51, 132, DateTimeKind.Utc).AddTicks(6463), false, "c191e5f8-bf5b-40a9-9ab6-4d08704e373b", 40000m, 13, 0, "Продам телевизор", null },
                    { 12, "299812 г. Судак, ул. Сергеева, 2", "Телевизор Xiaomi Mi TV 4S 50, 50, Ultra HD 4K", 10, new DateTime(2021, 11, 18, 9, 21, 51, 132, DateTimeKind.Utc).AddTicks(6461), false, "54b1ff98-6b5f-4c5e-97a9-747095e1f5dc", 40000m, 12, 0, "Продам телевизор", null },
                    { 11, "299411 г. Москва, ул. Тургенева, 1", "Телевизор Xiaomi Mi TV 4S 50, 50, Ultra HD 4K", 10, new DateTime(2021, 11, 18, 9, 21, 51, 132, DateTimeKind.Utc).AddTicks(6460), false, "64dbb199-0a95-4f1a-afcf-10cc827fd3c8", 40000m, 11, 0, "Продам телевизор", null },
                    { 10, "297415 г. Красноярск, ул. Достоевского, 5", "Телевизор Xiaomi Mi TV 4S 50, 50, Ultra HD 4K", 10, new DateTime(2021, 11, 18, 9, 21, 51, 132, DateTimeKind.Utc).AddTicks(6459), false, "7e24ccd2-34fd-4289-9a78-1aae93623bae", 40000m, 10, 0, "Продам телевизор", null },
                    { 9, "295314 г. Краснодар, ул. Чернышевского, 4", "Телевизор Xiaomi Mi TV 4S 50, 50, Ultra HD 4K", 10, new DateTime(2021, 11, 18, 9, 21, 51, 132, DateTimeKind.Utc).AddTicks(6458), false, "09c529c8-e798-44ac-9eac-e0150182fa4c", 40000m, 9, 0, "Продам телевизор", null },
                    { 8, "298413 г. Джанкой, ул. Куприна, 3", "Телевизор Xiaomi Mi TV 4S 50, 50, Ultra HD 4K", 10, new DateTime(2021, 11, 18, 9, 21, 51, 132, DateTimeKind.Utc).AddTicks(6456), false, "c191e5f8-bf5b-40a9-9ab6-4d08704e373b", 40000m, 8, 0, "Продам телевизор", null },
                    { 7, "297812 г. Астрахань, ул. Сергеева, 2", "Телевизор Xiaomi Mi TV 4S 50, 50, Ultra HD 4K", 10, new DateTime(2021, 11, 18, 9, 21, 51, 132, DateTimeKind.Utc).AddTicks(6455), false, "54b1ff98-6b5f-4c5e-97a9-747095e1f5dc", 40000m, 7, 0, "Продам телевизор", null },
                    { 6, "299411 г. Казань, ул. Тургенева, 1", "Телевизор Xiaomi Mi TV 4S 50, 50, Ultra HD 4K", 10, new DateTime(2021, 11, 18, 9, 21, 51, 132, DateTimeKind.Utc).AddTicks(6454), false, "64dbb199-0a95-4f1a-afcf-10cc827fd3c8", 40000m, 6, 0, "Продам телевизор", null },
                    { 5, "292415 г. Ялта, ул. Достоевского, 5", "Телевизор Xiaomi Mi TV 4S 50, 50, Ultra HD 4K", 10, new DateTime(2021, 11, 18, 9, 21, 51, 132, DateTimeKind.Utc).AddTicks(6453), false, "7e24ccd2-34fd-4289-9a78-1aae93623bae", 40000m, 5, 0, "Продам телевизор", null },
                    { 4, "295314 г. Симферополь, ул. Чернышевского, 4", "Телевизор Xiaomi Mi TV 4S 50, 50, Ultra HD 4K", 10, new DateTime(2021, 11, 18, 9, 21, 51, 132, DateTimeKind.Utc).AddTicks(6451), false, "09c529c8-e798-44ac-9eac-e0150182fa4c", 40000m, 4, 0, "Продам телевизор", null },
                    { 19, "295314 г. Краснодар, ул. Чернышевского, 4", "Телевизор Xiaomi Mi TV 4S 50, 50, Ultra HD 4K", 10, new DateTime(2021, 11, 18, 9, 21, 51, 132, DateTimeKind.Utc).AddTicks(6470), false, "09c529c8-e798-44ac-9eac-e0150182fa4c", 40000m, 19, 0, "Продам телевизор", null },
                    { 20, "297415 г. Красноярск, ул. Достоевского, 5", "Телевизор Xiaomi Mi TV 4S 50, 50, Ultra HD 4K", 10, new DateTime(2021, 11, 18, 9, 21, 51, 132, DateTimeKind.Utc).AddTicks(6471), false, "7e24ccd2-34fd-4289-9a78-1aae93623bae", 40000m, 20, 0, "Продам телевизор", null }
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
