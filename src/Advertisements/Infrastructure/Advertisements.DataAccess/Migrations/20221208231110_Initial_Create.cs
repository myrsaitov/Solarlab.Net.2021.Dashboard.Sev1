using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Advertisements.DataAccess.Migrations
{
    public partial class Initial_Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ParentCategoryId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ParentRegionId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Body = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Advertisements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Body = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: true),
                    OwnerId = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: true),
                    RegionId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advertisements_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Advertisements_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TagAdvertisement",
                columns: table => new
                {
                    AdvertisementsId = table.Column<int>(type: "integer", nullable: false),
                    TagsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagAdvertisement", x => new { x.AdvertisementsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_TagAdvertisement_Advertisements_AdvertisementsId",
                        column: x => x.AdvertisementsId,
                        principalTable: "Advertisements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagAdvertisement_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FileId = table.Column<int>(type: "integer", nullable: true),
                    AdvertisementId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "ParentCategoryId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 8, 23, 11, 10, 10, DateTimeKind.Utc).AddTicks(3414), false, "Транспорт", null, null },
                    { 5, new DateTime(2022, 12, 8, 23, 11, 10, 10, DateTimeKind.Utc).AddTicks(4388), false, "Недвижимость", null, null },
                    { 9, new DateTime(2022, 12, 8, 23, 11, 10, 10, DateTimeKind.Utc).AddTicks(4394), false, "Электроника", null, null },
                    { 18, new DateTime(2022, 12, 8, 23, 11, 10, 10, DateTimeKind.Utc).AddTicks(4405), false, "Искусство", null, null }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CreatedAt", "Name", "ParentRegionId" },
                values: new object[] { 1, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5272), "Российская Федерация", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "ParentCategoryId", "UpdatedAt" },
                values: new object[,]
                {
                    { 2, new DateTime(2022, 12, 8, 23, 11, 10, 10, DateTimeKind.Utc).AddTicks(4069), false, "Автомобили", 1, null },
                    { 20, new DateTime(2022, 12, 8, 23, 11, 10, 10, DateTimeKind.Utc).AddTicks(4408), false, "Акварель", 18, null },
                    { 19, new DateTime(2022, 12, 8, 23, 11, 10, 10, DateTimeKind.Utc).AddTicks(4406), false, "Живопись маслом", 18, null },
                    { 17, new DateTime(2022, 12, 8, 23, 11, 10, 10, DateTimeKind.Utc).AddTicks(4404), false, "Фототехника", 9, null },
                    { 15, new DateTime(2022, 12, 8, 23, 11, 10, 10, DateTimeKind.Utc).AddTicks(4401), false, "Телефоны", 9, null },
                    { 14, new DateTime(2022, 12, 8, 23, 11, 10, 10, DateTimeKind.Utc).AddTicks(4400), false, "Планшеты и электронные книги", 9, null },
                    { 13, new DateTime(2022, 12, 8, 23, 11, 10, 10, DateTimeKind.Utc).AddTicks(4399), false, "Ноутбуки", 9, null },
                    { 12, new DateTime(2022, 12, 8, 23, 11, 10, 10, DateTimeKind.Utc).AddTicks(4398), false, "Настольные компьютеры", 9, null },
                    { 16, new DateTime(2022, 12, 8, 23, 11, 10, 10, DateTimeKind.Utc).AddTicks(4403), false, "Товары для компьютера", 9, null },
                    { 10, new DateTime(2022, 12, 8, 23, 11, 10, 10, DateTimeKind.Utc).AddTicks(4395), false, "Аудио и видео", 9, null },
                    { 8, new DateTime(2022, 12, 8, 23, 11, 10, 10, DateTimeKind.Utc).AddTicks(4393), false, "Дома, дачи, коттеджи", 5, null },
                    { 7, new DateTime(2022, 12, 8, 23, 11, 10, 10, DateTimeKind.Utc).AddTicks(4391), false, "Комнаты", 5, null },
                    { 6, new DateTime(2022, 12, 8, 23, 11, 10, 10, DateTimeKind.Utc).AddTicks(4390), false, "Квартиры", 5, null },
                    { 4, new DateTime(2022, 12, 8, 23, 11, 10, 10, DateTimeKind.Utc).AddTicks(4387), false, "Грузовики и спецтехника", 1, null },
                    { 3, new DateTime(2022, 12, 8, 23, 11, 10, 10, DateTimeKind.Utc).AddTicks(4383), false, "Мотоциклы и мототехника", 1, null },
                    { 11, new DateTime(2022, 12, 8, 23, 11, 10, 10, DateTimeKind.Utc).AddTicks(4396), false, "Игры, приставки и программы", 9, null }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CreatedAt", "Name", "ParentRegionId" },
                values: new object[,]
                {
                    { 98, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5832), "Севастополь", 1 },
                    { 2, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5652), "Центральный федеральный округ", 1 },
                    { 21, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5679), "Северо-Западный федеральный округ", 1 },
                    { 33, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5693), "Южный федеральный округ", 1 },
                    { 47, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5773), "Приволжский федеральный округ", 1 },
                    { 63, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5791), "Уральский федеральный округ", 1 },
                    { 70, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5800), "Сибирский федеральный округ", 1 },
                    { 87, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5820), "Дальневосточный федеральный округ", 1 },
                    { 99, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5833), "Крым", 1 }
                });

            migrationBuilder.InsertData(
                table: "Advertisements",
                columns: new[] { "Id", "Address", "Body", "CategoryId", "CreatedAt", "IsDeleted", "OwnerId", "Price", "RegionId", "Status", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "299411 г. Москва, ул. Тургенева, 1", "Совокупность всех видов путей сообщения, транспортных средств, технических устройств и сооружений на путях сообщения, обеспечивающих процесс перемещения людей и грузов различного назначения из одного места в другое", 2, new DateTime(2022, 12, 8, 23, 11, 9, 993, DateTimeKind.Utc).AddTicks(5327), false, "64dbb199-0a95-4f1a-afcf-10cc827fd3c8", 100m, 1, 0, "Продам транспорт", null },
                    { 2, "299812 г. Судак, ул. Сергеева, 2", "Основное назначение автомобиля заключается в совершении транспортной работы. Автомобильный транспорт в промышленно развитых странах занимает ведущее место по сравнению с другими видами транспорта по объёму перевозок пассажиров. Современный автомобиль состоит из 15—20 тысяч деталей, из которых 150—300 являются наиболее важными и требующими наибольших затрат в эксплуатации", 2, new DateTime(2022, 12, 8, 23, 11, 9, 993, DateTimeKind.Utc).AddTicks(5696), false, "54b1ff98-6b5f-4c5e-97a9-747095e1f5dc", 400m, 2, 0, "Продам автомобиль", null },
                    { 21, "297415 г. Чебоксары, ул. Толстого, 25", "Интернет-планшет (англ. Internet tablet или Web tablet — Веб-планшет, или Pad tablet — Pad-планшет (Блокнотный планшет), или Web-pad — Веб-блокнот, или Surfpad — Веб-сёрфинг-блокнот) — мобильный компьютер, относящийся к типу планшетных компьютеров с диагональю экрана от 7 до 12 дюймов, построенный на аппаратной платформе того же класса, что и платформа для смартфонов.", 14, new DateTime(2022, 12, 8, 23, 11, 9, 993, DateTimeKind.Utc).AddTicks(5726), false, "64dbb199-0a95-4f1a-afcf-10cc827fd3c8", 44100m, 21, 0, "Продам планшет", null }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CreatedAt", "Name", "ParentRegionId" },
                values: new object[,]
                {
                    { 71, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5801), "Республика Алтай", 70 },
                    { 69, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5799), "в том числе Челябинская область", 63 },
                    { 68, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5797), "в том числе Ямало-Ненецкий автономный округ", 63 },
                    { 67, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5796), "в том числе Ханты-Мансийский автономный округ - Югра", 63 },
                    { 66, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5795), "Тюменская область", 63 },
                    { 65, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5794), "Свердловская область", 63 },
                    { 64, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5793), "Курганская область", 63 },
                    { 62, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5790), "Ульяновская область", 47 },
                    { 61, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5789), "Саратовская область", 47 },
                    { 60, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5788), "Самарская область", 47 },
                    { 59, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5787), "в том числе Коми-Пермяцкий автономный округ", 47 },
                    { 58, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5786), "Пермская область", 47 },
                    { 57, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5784), "Пензенская область", 47 },
                    { 56, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5783), "Оренбургская область", 47 },
                    { 55, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5782), "Нижегородская область", 47 },
                    { 54, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5781), "Кировская область", 47 },
                    { 53, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5780), "Чувашская Республика", 47 },
                    { 52, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5779), "Удмуртская Республика", 47 },
                    { 72, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5802), "Республика Бурятия", 70 },
                    { 73, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5803), "Республика Тыва", 70 },
                    { 75, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5805), "Алтайский край", 70 },
                    { 51, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5777), "Республика Татарстан", 47 },
                    { 95, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5829), "Сахалинская область", 87 },
                    { 94, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5828), "Магаданская область", 87 },
                    { 93, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5826), "Корякский автономный округ", 87 },
                    { 92, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5825), "Камчатская область", 87 },
                    { 91, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5824), "Амурская край", 87 },
                    { 90, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5823), "Хабаровский край", 87 },
                    { 89, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5822), "Приморский край", 87 },
                    { 88, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5821), "Республика Саха (Якутия)", 87 },
                    { 86, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5818), "в том числе Агинский Бурятский автономный округ", 70 },
                    { 85, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5817), "Читинская область", 70 },
                    { 84, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5816), "Томская область", 70 },
                    { 83, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5815), "Омская область", 70 },
                    { 82, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5814), "Новосибирская область", 70 },
                    { 81, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5813), "Кемеровская область", 70 },
                    { 80, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5812), "в том числе Усть-Ордынский Бурятский автономный округ", 70 },
                    { 79, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5810), "Иркутская область", 70 },
                    { 78, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5809), "Эвенкийский автономный округ", 70 },
                    { 77, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5808), "в том числе Таймырский (Долгано-Ненецкий) автономный округ", 70 },
                    { 76, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5807), "Красноярский край", 70 },
                    { 74, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5804), "Республика Хакасия", 70 },
                    { 50, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5776), "Республика Мордовия", 47 },
                    { 48, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5774), "Республика Башкортостан", 47 },
                    { 96, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5830), "Еврейская автономная область", 87 },
                    { 22, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5680), "Республика Карелия", 21 },
                    { 20, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5678), "г. Москва", 2 },
                    { 19, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5677), "Ярославская область", 2 },
                    { 18, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5675), "Тульская область", 2 },
                    { 17, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5672), "Тверская область", 2 },
                    { 16, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5671), "Тамбовская область", 2 },
                    { 15, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5670), "Смоленская область", 2 },
                    { 14, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5669), "Рязанская область", 2 },
                    { 13, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5667), "Орловская область", 2 },
                    { 12, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5666), "Московская область", 2 },
                    { 11, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5665), "Липецкая область", 2 },
                    { 10, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5664), "Курская область", 2 },
                    { 9, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5663), "Костромская область", 2 },
                    { 8, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5661), "Калужская область", 2 },
                    { 7, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5660), "Ивановская область", 2 },
                    { 6, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5659), "Воронежская область", 2 },
                    { 5, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5658), "Владимирская область", 2 },
                    { 4, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5657), "Брянская область", 2 },
                    { 3, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5655), "Белгородская область", 2 },
                    { 23, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5681), "Республика Коми", 21 },
                    { 49, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5775), "Республика Марий Эл", 47 },
                    { 24, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5682), "Архангельская область", 21 },
                    { 26, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5685), "Вологодская область", 21 },
                    { 46, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5772), "Ростовская область", 33 },
                    { 45, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5770), "Волгоградская область", 33 },
                    { 44, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5706), "Астраханская область", 33 },
                    { 43, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5705), "Ставропольский край", 33 },
                    { 42, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5704), "Краснодарский край", 33 },
                    { 41, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5703), "Чеченская Республика", 33 },
                    { 40, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5701), "Республика Северная Осетия - Алания", 33 },
                    { 39, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5700), "Карачаево-Черкесская Республика", 33 },
                    { 38, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5699), "Республика Калмыкия", 33 },
                    { 37, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5698), "Кабардино-Балкарская Республика", 33 },
                    { 36, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5696), "Республика Ингушетия", 33 },
                    { 35, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5695), "Республика Дагестан", 33 },
                    { 34, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5694), "Республика Адыгея", 33 },
                    { 32, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5691), "г. Санкт-Петербург", 21 },
                    { 31, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5690), "Псковская область", 21 },
                    { 30, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5689), "Новгородская область", 21 },
                    { 29, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5688), "Мурманская область", 21 },
                    { 28, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5687), "Ленинградская область", 21 },
                    { 27, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5686), "Калининградская область", 21 },
                    { 25, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5683), "в том числе Ненецкий автономный округ", 21 },
                    { 97, new DateTime(2022, 12, 8, 23, 11, 10, 16, DateTimeKind.Utc).AddTicks(5831), "Чукотский автономный округ", 87 }
                });

            migrationBuilder.InsertData(
                table: "Advertisements",
                columns: new[] { "Id", "Address", "Body", "CategoryId", "CreatedAt", "IsDeleted", "OwnerId", "Price", "RegionId", "Status", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 3, "293713 г. Керчь, ул. Куприна, 3", "Классические мотоциклы включают в себя двухколёсные, двухколёсные с боковой коляской, и трёхколёсные; в начале XXI века стали набирать популярность квадроциклы. Мотоциклы также подазделяются по своей конструкции и размерам: мопеды, мокики (имеют небольшой размер двигателя, как правило до 50 см³)", 3, new DateTime(2022, 12, 8, 23, 11, 9, 993, DateTimeKind.Utc).AddTicks(5699), false, "c191e5f8-bf5b-40a9-9ab6-4d08704e373b", 900m, 3, 0, "Продам мотоцикл", null },
                    { 23, "299812 г. Судак, ул. Сергеева, 2", "С точки зрения экономики и общества возможность осуществления телефонных переговоров рассматривается как благо и важное условие комфортной жизни человека. Существует область науки и техники, связанная с изучением направлений развития телефонной связи, она получила название телефонии.", 15, new DateTime(2022, 12, 8, 23, 11, 9, 993, DateTimeKind.Utc).AddTicks(5728), false, "c191e5f8-bf5b-40a9-9ab6-4d08704e373b", 52900m, 23, 0, "Продам телефон", null },
                    { 22, "299411 г. Москва, ул. Тургенева, 1", "Электро́нная кни́га (Electronic book; e-book; eBook) — версия книги, хранящаяся в электронном виде, и показываемая на экране, в цифровом формате. Данное понятие применяется как для произведений, представленных в цифровой форме, так и в отношении устройств, используемых для их прочтения.", 14, new DateTime(2022, 12, 8, 23, 11, 9, 993, DateTimeKind.Utc).AddTicks(5727), false, "54b1ff98-6b5f-4c5e-97a9-747095e1f5dc", 48400m, 22, 0, "Продам электронную книгу", null },
                    { 20, "297415 г. Красноярск, ул. Достоевского, 5", "Переносной компьютер, в корпусе которого объединены типичные компоненты ПК, включая дисплей, клавиатуру и устройство указания (обычно сенсорная панель или тачпад), а также аккумуляторные батареи. Ноутбуки отличаются небольшими размерами и весом, время автономной работы ноутбуков варьируется в пределах от 2 до 15 часов.", 13, new DateTime(2022, 12, 8, 23, 11, 9, 993, DateTimeKind.Utc).AddTicks(5724), false, "7e24ccd2-34fd-4289-9a78-1aae93623bae", 40000m, 20, 0, "Продам ноутбук", null },
                    { 19, "295314 г. Краснодар, ул. Чернышевского, 4", "Насто́льный (стационарный) компью́тер, дескто́п (англ. desktop computer) — стационарный персональный компьютер, предназначенный для работы в офисе и дома. Термин обычно используется для того, чтобы обозначить вид компьютера и отличить его от компьютеров других типов, например портативного компьютера, карманного компьютера, встроенного компьютера или сервера. Как правило, состоит из монитора, системного блока, мыши, клавиатуры и звукогарнитуры", 12, new DateTime(2022, 12, 8, 23, 11, 9, 993, DateTimeKind.Utc).AddTicks(5723), false, "09c529c8-e798-44ac-9eac-e0150182fa4c", 36100m, 19, 0, "Продам настольный компьютер б/у", null },
                    { 18, "298413 г. Джанкой, ул. Куприна, 3", "Игрова́я приста́вка (игровая консоль) — специализированное электронное устройство, предназначенное для видеоигр; для таких устройств, в отличие от персональных компьютеров, запуск и воспроизв", 11, new DateTime(2022, 12, 8, 23, 11, 9, 993, DateTimeKind.Utc).AddTicks(5721), false, "c191e5f8-bf5b-40a9-9ab6-4d08704e373b", 32400m, 18, 0, "Продам программу", null },
                    { 17, "297812 г. Астрахань, ул. Сергеева, 2", "Игрова́я приста́вка (игровая консоль) — специализированное электронное устройство, предназначенное для видеоигр; для таких устройств, в отличие от персональных компьютеров, запуск и воспроизв", 11, new DateTime(2022, 12, 8, 23, 11, 9, 993, DateTimeKind.Utc).AddTicks(5719), false, "54b1ff98-6b5f-4c5e-97a9-747095e1f5dc", 28900m, 17, 0, "Продам приставку", null },
                    { 16, "299411 г. Казань, ул. Тургенева, 1", "Игрова́я приста́вка (игровая консоль) — специализированное электронное устройство, предназначенное для видеоигр; для таких устройств, в отличие от персональных компьютеров, запуск и воспроизв", 11, new DateTime(2022, 12, 8, 23, 11, 9, 993, DateTimeKind.Utc).AddTicks(5718), false, "64dbb199-0a95-4f1a-afcf-10cc827fd3c8", 25600m, 16, 0, "Продам игру", null },
                    { 15, "292415 г. Ялта, ул. Достоевского, 5", "В середине 1980-х годов в СССР начали выпускать первые бытовые VHS- видеомагнитофоны «Электроника ВМ-12», которые стоили 1200 рублей (7-10 средних зарплат того времени[13]), но были дефицитным товаром и продавались по предварительной записи. Существовало даже такое понятие, как очередь на видеомагнитофон.", 10, new DateTime(2022, 12, 8, 23, 11, 9, 993, DateTimeKind.Utc).AddTicks(5716), false, "7e24ccd2-34fd-4289-9a78-1aae93623bae", 22500m, 15, 0, "Продам видеотехнику б/у", null },
                    { 14, "295314 г. Симферополь, ул. Чернышевского, 4", "Аудиотехника (звуковая техника, звукотехника, аудиоэлектроника) — аппаратура (магнитофоны, ревербераторы, микшеры, усилители, ресиверы и пр.) и устройства (микрофоны, динамики и пр.), предназначенные для записи и воспроизведения аудио (звука).", 10, new DateTime(2022, 12, 8, 23, 11, 9, 993, DateTimeKind.Utc).AddTicks(5715), false, "09c529c8-e798-44ac-9eac-e0150182fa4c", 19600m, 14, 0, "Продам аудиотехнику б/у", null },
                    { 13, "293713 г. Керчь, ул. Куприна, 3", "Возникновению электроники предшествовало открытие и изучение электричества, электромагнетизма, а далее изобретение радио. Поскольку радиопередатчики сразу же нашли применение (в первую очередь на кораблях и в военном деле), для них потребовалась элементная база, созданием и изучением которой и занялась электроника. Элементная база первого поколения была основана на электронных лампах. Соответственно получила развитие вакуумная электроника. Её развитию способствовало также изобретение телевидения и радаров, которые нашли широкое применение во время Второй мировой войны[2][3].Но электронные лампы обладали существенными недостатками. ", 10, new DateTime(2022, 12, 8, 23, 11, 9, 993, DateTimeKind.Utc).AddTicks(5714), false, "c191e5f8-bf5b-40a9-9ab6-4d08704e373b", 16900m, 13, 0, "Продам электронику", null },
                    { 12, "299812 г. Судак, ул. Сергеева, 2", "Котте́дж (от англ. cottage) — индивидуальный городской или сельский малоэтажный (обычно двухэтажный) жилой дом с небольшим участком прилегающей земли[1] для постоянного или временного проживания одной нуклеарной семьи. Первый этаж занимают такие помещения как гостиная, кухня, санузел, котельная, часто гараж для легкового автомобиля;", 8, new DateTime(2022, 12, 8, 23, 11, 9, 993, DateTimeKind.Utc).AddTicks(5712), false, "54b1ff98-6b5f-4c5e-97a9-747095e1f5dc", 14400m, 12, 0, "Продам котедж", null },
                    { 11, "299411 г. Москва, ул. Тургенева, 1", "Котте́дж (от англ. cottage) — индивидуальный городской или сельский малоэтажный (обычно двухэтажный) жилой дом с небольшим участком прилегающей земли[1] для постоянного или временного проживания одной нуклеарной семьи. Первый этаж занимают такие помещения как гостиная, кухня, санузел, котельная, часто гараж для легкового автомобиля;", 8, new DateTime(2022, 12, 8, 23, 11, 9, 993, DateTimeKind.Utc).AddTicks(5711), false, "64dbb199-0a95-4f1a-afcf-10cc827fd3c8", 12100m, 11, 0, "Продам дачу", null },
                    { 10, "297415 г. Красноярск, ул. Достоевского, 5", "Котте́дж (от англ. cottage) — индивидуальный городской или сельский малоэтажный (обычно двухэтажный) жилой дом с небольшим участком прилегающей земли[1] для постоянного или временного проживания одной нуклеарной семьи. Первый этаж занимают такие помещения как гостиная, кухня, санузел, котельная, часто гараж для легкового автомобиля;", 8, new DateTime(2022, 12, 8, 23, 11, 9, 993, DateTimeKind.Utc).AddTicks(5710), false, "7e24ccd2-34fd-4289-9a78-1aae93623bae", 10000m, 10, 0, "Продам дом", null },
                    { 9, "295314 г. Краснодар, ул. Чернышевского, 4", "Кварти́ра (от нем. Quartier[1]) — один из видов жилого помещения, состоящий из одной или нескольких смежных комнат а также в отдельных случаях с отдельным наружным выходом, составляющее отдельную часть дома.", 7, new DateTime(2022, 12, 8, 23, 11, 9, 993, DateTimeKind.Utc).AddTicks(5708), false, "09c529c8-e798-44ac-9eac-e0150182fa4c", 8100m, 9, 0, "Продам комнату", null },
                    { 8, "298413 г. Джанкой, ул. Куприна, 3", "Кварти́ра (от нем. Quartier[1]) — один из видов жилого помещения, состоящий из одной или нескольких смежных комнат а также в отдельных случаях с отдельным наружным выходом, составляющее отдельную часть дома.", 6, new DateTime(2022, 12, 8, 23, 11, 9, 993, DateTimeKind.Utc).AddTicks(5707), false, "c191e5f8-bf5b-40a9-9ab6-4d08704e373b", 6400m, 8, 0, "Продам квартиру", null },
                    { 7, "297812 г. Астрахань, ул. Сергеева, 2", "Недви́жимость — вид имущества, признаваемого в законодательном порядке недвижимым. К недвижимости по происхождению относятся земельные участки, участки недр и все, что прочно связано с землёй, то есть объекты, перемещение которых без несоразмерного ущерба их назначению невозможно, в том числе здания, сооружения, объекты незавершённого строительства.", 6, new DateTime(2022, 12, 8, 23, 11, 9, 993, DateTimeKind.Utc).AddTicks(5705), false, "54b1ff98-6b5f-4c5e-97a9-747095e1f5dc", 4900m, 7, 0, "Продам недвижимость", null },
                    { 6, "299411 г. Казань, ул. Тургенева, 1", "За считанные месяцы были разработаны, изготовлены и подготовлены к участию во Всесоюзном мотопробеге пять мотоциклов пяти различных моделей. Наиболее удачными были мотоциклы — колоссы «Иж-1» и «Иж-2» с двухцилиндровыми V-образными двигателями рабочим объёмом 1200 см³ и максимальной мощностью 24 л. с. Для своего времени это были чрезвычайно оригинальные и передовые конструкции. Коленчатый вал двигателя располагался продольно, крутящий момент на заднее колесо передавался от трёхступенчатой коробки передач,", 4, new DateTime(2022, 12, 8, 23, 11, 9, 993, DateTimeKind.Utc).AddTicks(5703), false, "64dbb199-0a95-4f1a-afcf-10cc827fd3c8", 3600m, 6, 0, "Продам спецтехнику", null },
                    { 5, "292415 г. Ялта, ул. Достоевского, 5", "Грузовой автомобиль (разг. грузовик) — автомобиль, предназначенный для перевозки грузов в кузове или на грузовой платформе. Для обобщённого обозначения машин, созданных на базе грузового автомобиля, используется термин грузовая техника.", 4, new DateTime(2022, 12, 8, 23, 11, 9, 993, DateTimeKind.Utc).AddTicks(5702), false, "7e24ccd2-34fd-4289-9a78-1aae93623bae", 2500m, 5, 0, "Продам грузовик б/у", null },
                    { 4, "295314 г. Симферополь, ул. Чернышевского, 4", "Классические мотоциклы включают в себя двухколёсные, двухколёсные с боковой коляской, и трёхколёсные; в начале XXI века стали набирать популярность квадроциклы. Мотоциклы также подазделяются по своей конструкции и размерам: мопеды, мокики (имеют небольшой размер двигателя, как правило до 50 см³)", 3, new DateTime(2022, 12, 8, 23, 11, 9, 993, DateTimeKind.Utc).AddTicks(5701), false, "09c529c8-e798-44ac-9eac-e0150182fa4c", 1600m, 4, 0, "Продам мототехнику б/у", null },
                    { 24, "293713 г. Керчь, ул. Куприна, 3", "Комплементарные блага (взаимодополняющие товары) — блага, совместное потребление которых является для агента более предпочтительным, чем потребление каждого", 16, new DateTime(2022, 12, 8, 23, 11, 9, 993, DateTimeKind.Utc).AddTicks(5730), false, "09c529c8-e798-44ac-9eac-e0150182fa4c", 57600m, 24, 0, "Продам товары для компьютера", null },
                    { 25, "295314 г. Симферополь, ул. Чернышевского, 4", "Фотоаппара́т (фотографи́ческий аппара́т, фотока́мера) — устройство для регистрации неподвижных изображений (получения фотографий). Запись изображения в фотоаппарате осуществляется фотохимическим способом при воздействии света на светочувствительный фотоматериал. Получаемое таким способом скрытое изображение преобразуется в видимое при лабораторной обработке. В цифровом фотоаппарате фотофиксация происходит путём фотоэлектрического преобразования оптического изображения в электрический сигнал, цифровые данные о котором сохраняются на энергонезависимом носителе.", 17, new DateTime(2022, 12, 8, 23, 11, 9, 993, DateTimeKind.Utc).AddTicks(5731), false, "7e24ccd2-34fd-4289-9a78-1aae93623bae", 62500m, 25, 0, "Продам фотоаппарат б/у", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_CategoryId",
                table: "Advertisements",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_RegionId",
                table: "Advertisements",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_ParentRegionId",
                table: "Regions",
                column: "ParentRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_TagAdvertisement_TagsId",
                table: "TagAdvertisement",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFiles_AdvertisementId",
                table: "UserFiles",
                column: "AdvertisementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagAdvertisement");

            migrationBuilder.DropTable(
                name: "UserFiles");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Advertisements");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
