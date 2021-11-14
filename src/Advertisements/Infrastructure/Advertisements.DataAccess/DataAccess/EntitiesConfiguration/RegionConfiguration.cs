using System;
using Sev1.Advertisements.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sev1.Advertisements.DataAccess.EntitiesConfiguration
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {

        // Начальное сидирование категорий в базу
        private Region[] regions = new Region[]
        {
            // Российская Федерация
            new Region
            {
                Id = 1,
                Name = "Российская Федерация",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = null,
                IsDeleted = false
            },

            // Центральный федеральный округ
            new Region
            {
                Id = 2,
                Name = "Центральный федеральный округ",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 1,
                IsDeleted = false
            },
            new Region
            {
                Id = 3,
                Name = "Белгородская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 2,
                IsDeleted = false
            },
            new Region
            {
                Id = 4,
                Name = "Брянская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 2,
                IsDeleted = false
            },
            new Region
            {
                Id = 5,
                Name = "Владимирская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 2,
                IsDeleted = false
            },
            new Region
            {
                Id = 6,
                Name = "Воронежская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 2,
                IsDeleted = false
            },
            new Region
            {
                Id = 7,
                Name = "Ивановская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 2,
                IsDeleted = false
            },
            new Region
            {
                Id = 8,
                Name = "Калужская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 2,
                IsDeleted = false
            },
            new Region
            {
                Id = 9,
                Name = "Костромская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 2,
                IsDeleted = false
            },
            new Region
            {
                Id = 10,
                Name = "Курская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 2,
                IsDeleted = false
            },
            new Region
            {
                Id = 11,
                Name = "Липецкая область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 2,
                IsDeleted = false
            },
            new Region
            {
                Id = 12,
                Name = "Московская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 2,
                IsDeleted = false
            },
            new Region
            {
                Id = 13,
                Name = "Орловская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 2,
                IsDeleted = false
            },
            new Region
            {
                Id = 14,
                Name = "Рязанская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 2,
                IsDeleted = false
            },
            new Region
            {
                Id = 15,
                Name = "Смоленская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 2,
                IsDeleted = false
            },
            new Region
            {
                Id = 16,
                Name = "Тамбовская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 2,
                IsDeleted = false
            },
            new Region
            {
                Id = 17,
                Name = "Тверская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 2,
                IsDeleted = false
            },
            new Region
            {
                Id = 18,
                Name = "Тульская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 2,
                IsDeleted = false
            },
            new Region
            {
                Id = 19,
                Name = "Ярославская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 2,
                IsDeleted = false
            },
            new Region
            {
                Id = 20,
                Name = "г. Москва",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 2,
                IsDeleted = false
            },

            // Северо-Западный федеральный округ
            new Region
            {
                Id = 21,
                Name = "Северо-Западный федеральный округ",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 1,
                IsDeleted = false
            },
            new Region
            {
                Id = 22,
                Name = "Республика Карелия",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 21,
                IsDeleted = false
            },
            new Region
            {
                Id = 23,
                Name = "Республика Коми",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 21,
                IsDeleted = false
            },
            new Region
            {
                Id = 24,
                Name = "Архангельская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 21,
                IsDeleted = false
            },
            new Region
            {
                Id = 25,
                Name = "в том числе Ненецкий автономный округ",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 21,
                IsDeleted = false
            },
            new Region
            {
                Id = 26,
                Name = "Вологодская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 21,
                IsDeleted = false
            },
            new Region
            {
                Id = 27,
                Name = "Калининградская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 21,
                IsDeleted = false
            },
            new Region
            {
                Id = 28,
                Name = "Ленинградская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 21,
                IsDeleted = false
            },
            new Region
            {
                Id = 29,
                Name = "Мурманская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 21,
                IsDeleted = false
            },
            new Region
            {
                Id = 30,
                Name = "Новгородская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 21,
                IsDeleted = false
            },
            new Region
            {
                Id = 31,
                Name = "Псковская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 21,
                IsDeleted = false
            },
            new Region
            {
                Id = 32,
                Name = "г. Санкт-Петербург",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 21,
                IsDeleted = false
            },

            // Южный федеральный округ
            new Region
            {
                Id = 33,
                Name = "Южный федеральный округ",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 1,
                IsDeleted = false
            },
            new Region
            {
                Id = 34,
                Name = "Республика Адыгея",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 33,
                IsDeleted = false
            },
            new Region
            {
                Id = 35,
                Name = "Республика Дагестан",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 33,
                IsDeleted = false
            },
            new Region
            {
                Id = 36,
                Name = "Республика Ингушетия",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 33,
                IsDeleted = false
            },
            new Region
            {
                Id = 37,
                Name = "Кабардино-Балкарская Республика",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 33,
                IsDeleted = false
            },
            new Region
            {
                Id = 38,
                Name = "Республика Калмыкия",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 33,
                IsDeleted = false
            },
            new Region
            {
                Id = 39,
                Name = "Карачаево-Черкесская Республика",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 33,
                IsDeleted = false
            },
            new Region
            {
                Id = 40,
                Name = "Республика Северная Осетия - Алания",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 33,
                IsDeleted = false
            },
            new Region
            {
                Id = 41,
                Name = "Чеченская Республика",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 33,
                IsDeleted = false
            },
            new Region
            {
                Id = 42,
                Name = "Краснодарский край",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 33,
                IsDeleted = false
            },
            new Region
            {
                Id = 43,
                Name = "Ставропольский край",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 33,
                IsDeleted = false
            },
            new Region
            {
                Id = 44,
                Name = "Астраханская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 33,
                IsDeleted = false
            },
            new Region
            {
                Id = 45,
                Name = "Волгоградская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 33,
                IsDeleted = false
            },
            new Region
            {
                Id = 46,
                Name = "Ростовская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 33,
                IsDeleted = false
            },

            // Приволжский федеральный округ
            new Region
            {
                Id = 47,
                Name = "Приволжский федеральный округ",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 1,
                IsDeleted = false
            },
            new Region
            {
                Id = 48,
                Name = "Республика Башкортостан",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 47,
                IsDeleted = false
            },
            new Region
            {
                Id = 49,
                Name = "Республика Марий Эл",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 47,
                IsDeleted = false
            },
            new Region
            {
                Id = 50,
                Name = "Республика Мордовия",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 47,
                IsDeleted = false
            },
            new Region
            {
                Id = 51,
                Name = "Республика Татарстан",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 47,
                IsDeleted = false
            },
            new Region
            {
                Id = 52,
                Name = "Удмуртская Республика",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 47,
                IsDeleted = false
            },
            new Region
            {
                Id = 53,
                Name = "Чувашская Республика",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 47,
                IsDeleted = false
            },
            new Region
            {
                Id = 54,
                Name = "Кировская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 47,
                IsDeleted = false
            },
            new Region
            {
                Id = 55,
                Name = "Нижегородская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 47,
                IsDeleted = false
            },
            new Region
            {
                Id = 56,
                Name = "Оренбургская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 47,
                IsDeleted = false
            },
            new Region
            {
                Id = 57,
                Name = "Пензенская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 47,
                IsDeleted = false
            },
            new Region
            {
                Id = 58,
                Name = "Пермская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 47,
                IsDeleted = false
            },
            new Region
            {
                Id = 59,
                Name = "в том числе Коми-Пермяцкий автономный округ",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 47,
                IsDeleted = false
            },
            new Region
            {
                Id = 60,
                Name = "Самарская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 47,
                IsDeleted = false
            },
            new Region
            {
                Id = 61,
                Name = "Саратовская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 47,
                IsDeleted = false
            },
            new Region
            {
                Id = 62,
                Name = "Ульяновская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 47,
                IsDeleted = false
            },

            // Уральский федеральный округ
            new Region
            {
                Id = 63,
                Name = "Уральский федеральный округ",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 1,
                IsDeleted = false
            },
            new Region
            {
                Id = 64,
                Name = "Курганская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 63,
                IsDeleted = false
            },
            new Region
            {
                Id = 65,
                Name = "Свердловская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 63,
                IsDeleted = false
            },
            new Region
            {
                Id = 66,
                Name = "Тюменская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 63,
                IsDeleted = false
            },
            new Region
            {
                Id = 67,
                Name = "в том числе Ханты-Мансийский автономный округ - Югра",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 63,
                IsDeleted = false
            },
            new Region
            {
                Id = 68,
                Name = "в том числе Ямало-Ненецкий автономный округ",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 63,
                IsDeleted = false
            },
            new Region
            {
                Id = 69,
                Name = "в том числе Челябинская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 63,
                IsDeleted = false
            },

            // Сибирский федеральный округ
            new Region
            {
                Id = 70,
                Name = "Сибирский федеральный округ",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 1,
                IsDeleted = false
            },
            new Region
            {
                Id = 71,
                Name = "Республика Алтай",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 70,
                IsDeleted = false
            },
            new Region
            {
                Id = 72,
                Name = "Республика Бурятия",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 70,
                IsDeleted = false
            },
            new Region
            {
                Id = 73,
                Name = "Республика Тыва",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 70,
                IsDeleted = false
            },
            new Region
            {
                Id = 74,
                Name = "Республика Хакасия",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 70,
                IsDeleted = false
            },
            new Region
            {
                Id = 75,
                Name = "Алтайский край",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 70,
                IsDeleted = false
            },
            new Region
            {
                Id = 76,
                Name = "Красноярский край",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 70,
                IsDeleted = false
            },
            new Region
            {
                Id = 77,
                Name = "в том числе Таймырский (Долгано-Ненецкий) автономный округ",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 70,
                IsDeleted = false
            },
            new Region
            {
                Id = 78,
                Name = "Эвенкийский автономный округ",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 70,
                IsDeleted = false
            },
            new Region
            {
                Id = 79,
                Name = "Иркутская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 70,
                IsDeleted = false
            },
            new Region
            {
                Id = 80,
                Name = "в том числе Усть-Ордынский Бурятский автономный округ",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 70,
                IsDeleted = false
            },
            new Region
            {
                Id = 81,
                Name = "Кемеровская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 70,
                IsDeleted = false
            },
            new Region
            {
                Id = 82,
                Name = "Новосибирская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 70,
                IsDeleted = false
            },
            new Region
            {
                Id = 83,
                Name = "Омская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 70,
                IsDeleted = false
            },
            new Region
            {
                Id = 84,
                Name = "Томская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 70,
                IsDeleted = false
            },
            new Region
            {
                Id = 85,
                Name = "Читинская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 70,
                IsDeleted = false
            },
            new Region
            {
                Id = 86,
                Name = "в том числе Агинский Бурятский автономный округ",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 70,
                IsDeleted = false
            },

            // Дальневосточный федеральный округ
            new Region
            {
                Id = 87,
                Name = "Дальневосточный федеральный округ",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 1,
                IsDeleted = false
            },
            new Region
            {
                Id = 88,
                Name = "Республика Саха (Якутия)",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 87,
                IsDeleted = false
            },
            new Region
            {
                Id = 89,
                Name = "Приморский край",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 87,
                IsDeleted = false
            },
            new Region
            {
                Id = 90,
                Name = "Хабаровский край",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 87,
                IsDeleted = false
            },
            new Region
            {
                Id = 91,
                Name = "Амурская край",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 87,
                IsDeleted = false
            },
            new Region
            {
                Id = 92,
                Name = "Камчатская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 87,
                IsDeleted = false
            },
            new Region
            {
                Id = 93,
                Name = "Корякский автономный округ",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 87,
                IsDeleted = false
            },
            new Region
            {
                Id = 94,
                Name = "Магаданская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 87,
                IsDeleted = false
            },
            new Region
            {
                Id = 95,
                Name = "Сахалинская область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 87,
                IsDeleted = false
            },
            new Region
            {
                Id = 96,
                Name = "Еврейская автономная область",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 87,
                IsDeleted = false
            },
            new Region
            {
                Id = 97,
                Name = "Чукотский автономный округ",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 87,
                IsDeleted = false
            },

            // Севастополь
            new Region
            {
                Id = 98,
                Name = "Севастополь",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 1,
                IsDeleted = false
            },

            // Крым
            new Region
            {
                Id = 99,
                Name = "Крым",
                CreatedAt = DateTime.UtcNow,
                ParentRegionId = 1,
                IsDeleted = false
            },
        };

        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.CreatedAt).IsRequired();
            builder.HasData(regions);
        }
    }
}