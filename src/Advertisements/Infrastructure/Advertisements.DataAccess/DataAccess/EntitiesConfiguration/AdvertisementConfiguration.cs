using Sev1.Advertisements.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using sev1.Advertisements.Contracts.Enums;

namespace Sev1.Advertisements.DataAccess.EntitiesConfiguration
{
    public class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement>
    {
        private static string USER_ID_1 = "64dbb199-0a95-4f1a-afcf-10cc827fd3c8";
        private static string USER_ID_2 = "54b1ff98-6b5f-4c5e-97a9-747095e1f5dc";
        private static string USER_ID_3 = "c191e5f8-bf5b-40a9-9ab6-4d08704e373b";
        private static string USER_ID_4 = "09c529c8-e798-44ac-9eac-e0150182fa4c";
        private static string USER_ID_5 = "7e24ccd2-34fd-4289-9a78-1aae93623bae";

        private static string ADDR_1 = "299411 г. Москва, ул. Тургенева, 1";
        private static string ADDR_2 = "299812 г. Судак, ул. Сергеева, 2";
        private static string ADDR_3 = "299713 г. Керчь, ул. Куприна, 3";
        private static string ADDR_4 = "299314 г. Симферополь, ул. Чернышевского, 4";
        private static string ADDR_5 = "299415 г. Ялта, ул. Достоевского, 5";

        // Начальное сидирование категорий в базу
        private Advertisement[] advertisements = new Advertisement[]
        {
            new Advertisement
            {
                Id = 1,
                Title = "Продам телевизор",
                Body = "Телевизор Xiaomi Mi TV 4S 50, 50, Ultra HD 4K",
                Price = 40000,
                CategoryId = 10,
                OwnerId = USER_ID_1,
                Status = AdvertisementStatus.Active,
                Address = ADDR_1,
                RegionId = 1,
                CreatedAt = DateTime.UtcNow,
            },
            new Advertisement
            {
                Id = 2,
                Title = "Продам магнитофон",
                Body = "Магнитофон (от магнит и греч. φωνή звук) — электромеханическое устройство, предназначенное для записи звуковой информации на магнитные носители и/или её воспроизведения. В качестве носителя используются материалы с магнитными свойствами: магнитная лента, проволока, магнитные манжеты, диски, барабаны и т. д.",
                Price = 2000,
                CategoryId = 10,
                OwnerId = USER_ID_2,
                Status = AdvertisementStatus.Active,
                Address = ADDR_2,
                RegionId = 2,
                CreatedAt = DateTime.UtcNow,
            },
            new Advertisement
            {
                Id = 3,
                Title = "Телевизор",
                Body = "Телевизор Xiaomi Mi TV 4S 50, 50, Ultra HD 4K",
                Price = 40000,
                CategoryId = 10,
                OwnerId = USER_ID_3,
                Status = AdvertisementStatus.Active,
                Address = ADDR_3,
                RegionId = 3,
                CreatedAt = DateTime.UtcNow,
            },
            new Advertisement
            {
                Id = 4,
                Title = "Магнитофон",
                Body = "Магнитофон (от магнит и греч. φωνή звук) — электромеханическое устройство, предназначенное для записи звуковой информации на магнитные носители и/или её воспроизведения. В качестве носителя используются материалы с магнитными свойствами: магнитная лента, проволока, магнитные манжеты, диски, барабаны и т. д.",
                Price = 2000,
                CategoryId = 10,
                OwnerId = USER_ID_4,
                Status = AdvertisementStatus.Active,
                Address = ADDR_4,
                RegionId = 4,
                CreatedAt = DateTime.UtcNow,
            },
            new Advertisement
            {
                Id = 5,
                Title = "Стиральная машина",
                Body = "Примитивные стиральные машины представляли собой деревянный ящик с подвижной рамой. Первая стиральная машина, запущенная в серийное производство, была создана в 1907 году[источник не указан 109 дней] Уильямом Блекстоуном, у неё был ручной привод (есть также мнение, что первую сделал Натаниэл Бриггс (Nathaniel Briggs)). В Европе первые стиральные машины начали производить в Германии в 1900 г. Современные машины с электрическим приводом появились в 1904 году[1]. Механизация труда практически привела к исчезновению профессии прачки. В 1949 году в США появилась первая автоматическая стиральная машина.",
                Price = 10000,
                CategoryId = 9,
                OwnerId = USER_ID_5,
                Status = AdvertisementStatus.Active,
                Address = ADDR_5,
                RegionId = 5,
                CreatedAt = DateTime.UtcNow,
            },
            new Advertisement
            {
                Id = 6,
                Title = "Видеомагнитофон",
                Body = "Видеомагнитофо́н — устройство для записи телевизионного сигнала на магнитную ленту и его последующего воспроизведения[1][2]. От магнитофона отличается многократно увеличенной полосой записываемых частот и устройством лентопротяжного механизма[3]. Получаемая при помощи видеомагнитофона запись изображения и звука называется видеофонограммой[4][5]. Возможность записи высокочастотных и импульсных сигналов делает видеомагнитофон пригодным не только для видеозаписи, но и для других прикладных задач, связанных с регистрацией информации.",
                Price = 40000,
                CategoryId = 10,
                OwnerId = USER_ID_2,
                Status = AdvertisementStatus.Active,
                Address = ADDR_2,
                RegionId = 7,
                CreatedAt = DateTime.UtcNow,
            },
            new Advertisement
            {
                Id = 7,
                Title = "Куплю магнитофон",
                Body = "Магнитофон (от магнит и греч. φωνή звук) — электромеханическое устройство, предназначенное для записи звуковой информации на магнитные носители и/или её воспроизведения. В качестве носителя используются материалы с магнитными свойствами: магнитная лента, проволока, магнитные манжеты, диски, барабаны и т. д.",
                Price = 2000,
                CategoryId = 10,
                OwnerId = USER_ID_3,
                Status = AdvertisementStatus.Active,
                Address = ADDR_3,
                RegionId = 8,
                CreatedAt = DateTime.UtcNow,
            },
            new Advertisement
            {
                Id = 8,
                Title = "Стиральная машина",
                Body = "Примитивные стиральные машины представляли собой деревянный ящик с подвижной рамой. Первая стиральная машина, запущенная в серийное производство, была создана в 1907 году[источник не указан 109 дней] Уильямом Блекстоуном, у неё был ручной привод (есть также мнение, что первую сделал Натаниэл Бриггс (Nathaniel Briggs)). В Европе первые стиральные машины начали производить в Германии в 1900 г. Современные машины с электрическим приводом появились в 1904 году[1]. Механизация труда практически привела к исчезновению профессии прачки. В 1949 году в США появилась первая автоматическая стиральная машина.",
                Price = 2000,
                CategoryId = 9,
                OwnerId = USER_ID_4,
                Status = AdvertisementStatus.Active,
                Address = ADDR_4,
                RegionId = 6,
                CreatedAt = DateTime.UtcNow,
            },
            new Advertisement
            {
                Id = 9,
                Title = "Продам телевизор",
                Body = "Телевизор Xiaomi Mi TV 4S 50, 50, Ultra HD 4K",
                Price = 40000,
                CategoryId = 10,
                OwnerId = USER_ID_1,
                Status = AdvertisementStatus.Active,
                Address = ADDR_1,
                RegionId = 1,
                CreatedAt = DateTime.UtcNow,
            },
            new Advertisement
            {
                Id = 10,
                Title = "Продам магнитофон",
                Body = "Магнитофон (от магнит и греч. φωνή звук) — электромеханическое устройство, предназначенное для записи звуковой информации на магнитные носители и/или её воспроизведения. В качестве носителя используются материалы с магнитными свойствами: магнитная лента, проволока, магнитные манжеты, диски, барабаны и т. д.",
                Price = 2000,
                CategoryId = 10,
                OwnerId = USER_ID_2,
                Status = AdvertisementStatus.Active,
                Address = ADDR_2,
                RegionId = 2,
                CreatedAt = DateTime.UtcNow,
            },
            new Advertisement
            {
                Id = 11,
                Title = "Телевизор",
                Body = "Телевизор Xiaomi Mi TV 4S 50, 50, Ultra HD 4K",
                Price = 40000,
                CategoryId = 10,
                OwnerId = USER_ID_3,
                Status = AdvertisementStatus.Active,
                Address = ADDR_3,
                RegionId = 3,
                CreatedAt = DateTime.UtcNow,
            },
            new Advertisement
            {
                Id = 12,
                Title = "Магнитофон",
                Body = "Магнитофон (от магнит и греч. φωνή звук) — электромеханическое устройство, предназначенное для записи звуковой информации на магнитные носители и/или её воспроизведения. В качестве носителя используются материалы с магнитными свойствами: магнитная лента, проволока, магнитные манжеты, диски, барабаны и т. д.",
                Price = 2000,
                CategoryId = 10,
                OwnerId = USER_ID_4,
                Status = AdvertisementStatus.Active,
                Address = ADDR_4,
                RegionId = 4,
                CreatedAt = DateTime.UtcNow,
            },
            new Advertisement
            {
                Id = 13,
                Title = "Стиральная машина",
                Body = "Примитивные стиральные машины представляли собой деревянный ящик с подвижной рамой. Первая стиральная машина, запущенная в серийное производство, была создана в 1907 году[источник не указан 109 дней] Уильямом Блекстоуном, у неё был ручной привод (есть также мнение, что первую сделал Натаниэл Бриггс (Nathaniel Briggs)). В Европе первые стиральные машины начали производить в Германии в 1900 г. Современные машины с электрическим приводом появились в 1904 году[1]. Механизация труда практически привела к исчезновению профессии прачки. В 1949 году в США появилась первая автоматическая стиральная машина.",
                Price = 10000,
                CategoryId = 9,
                OwnerId = USER_ID_5,
                Status = AdvertisementStatus.Active,
                Address = ADDR_5,
                RegionId = 5,
                CreatedAt = DateTime.UtcNow,
            },
            new Advertisement
            {
                Id = 14,
                Title = "Видеомагнитофон",
                Body = "Видеомагнитофо́н — устройство для записи телевизионного сигнала на магнитную ленту и его последующего воспроизведения[1][2]. От магнитофона отличается многократно увеличенной полосой записываемых частот и устройством лентопротяжного механизма[3]. Получаемая при помощи видеомагнитофона запись изображения и звука называется видеофонограммой[4][5]. Возможность записи высокочастотных и импульсных сигналов делает видеомагнитофон пригодным не только для видеозаписи, но и для других прикладных задач, связанных с регистрацией информации.",
                Price = 40000,
                CategoryId = 10,
                OwnerId = USER_ID_2,
                Status = AdvertisementStatus.Active,
                Address = ADDR_2,
                RegionId = 7,
                CreatedAt = DateTime.UtcNow,
            },
            new Advertisement
            {
                Id = 15,
                Title = "Куплю магнитофон",
                Body = "Магнитофон (от магнит и греч. φωνή звук) — электромеханическое устройство, предназначенное для записи звуковой информации на магнитные носители и/или её воспроизведения. В качестве носителя используются материалы с магнитными свойствами: магнитная лента, проволока, магнитные манжеты, диски, барабаны и т. д.",
                Price = 2000,
                CategoryId = 10,
                OwnerId = USER_ID_3,
                Status = AdvertisementStatus.Active,
                Address = ADDR_3,
                RegionId = 8,
                CreatedAt = DateTime.UtcNow,
            },
            new Advertisement
            {
                Id = 16,
                Title = "Стиральная машина",
                Body = "Примитивные стиральные машины представляли собой деревянный ящик с подвижной рамой. Первая стиральная машина, запущенная в серийное производство, была создана в 1907 году[источник не указан 109 дней] Уильямом Блекстоуном, у неё был ручной привод (есть также мнение, что первую сделал Натаниэл Бриггс (Nathaniel Briggs)). В Европе первые стиральные машины начали производить в Германии в 1900 г. Современные машины с электрическим приводом появились в 1904 году[1]. Механизация труда практически привела к исчезновению профессии прачки. В 1949 году в США появилась первая автоматическая стиральная машина.",
                Price = 2000,
                CategoryId = 9,
                OwnerId = USER_ID_4,
                Status = AdvertisementStatus.Active,
                Address = ADDR_4,
                RegionId = 6,
                CreatedAt = DateTime.UtcNow,
            },
            new Advertisement
            {
                Id = 17,
                Title = "Магнитофон",
                Body = "Магнитофон (от магнит и греч. φωνή звук) — электромеханическое устройство, предназначенное для записи звуковой информации на магнитные носители и/или её воспроизведения. В качестве носителя используются материалы с магнитными свойствами: магнитная лента, проволока, магнитные манжеты, диски, барабаны и т. д.",
                Price = 2000,
                CategoryId = 10,
                OwnerId = USER_ID_4,
                Status = AdvertisementStatus.Active,
                Address = ADDR_4,
                RegionId = 4,
                CreatedAt = DateTime.UtcNow,
            },
            new Advertisement
            {
                Id = 18,
                Title = "Стиральная машина",
                Body = "Примитивные стиральные машины представляли собой деревянный ящик с подвижной рамой. Первая стиральная машина, запущенная в серийное производство, была создана в 1907 году[источник не указан 109 дней] Уильямом Блекстоуном, у неё был ручной привод (есть также мнение, что первую сделал Натаниэл Бриггс (Nathaniel Briggs)). В Европе первые стиральные машины начали производить в Германии в 1900 г. Современные машины с электрическим приводом появились в 1904 году[1]. Механизация труда практически привела к исчезновению профессии прачки. В 1949 году в США появилась первая автоматическая стиральная машина.",
                Price = 10000,
                CategoryId = 9,
                OwnerId = USER_ID_4,
                Status = AdvertisementStatus.Active,
                Address = ADDR_4,
                RegionId = 5,
                CreatedAt = DateTime.UtcNow,
            },
            new Advertisement
            {
                Id = 19,
                Title = "Видеомагнитофон",
                Body = "Видеомагнитофо́н — устройство для записи телевизионного сигнала на магнитную ленту и его последующего воспроизведения[1][2]. От магнитофона отличается многократно увеличенной полосой записываемых частот и устройством лентопротяжного механизма[3]. Получаемая при помощи видеомагнитофона запись изображения и звука называется видеофонограммой[4][5]. Возможность записи высокочастотных и импульсных сигналов делает видеомагнитофон пригодным не только для видеозаписи, но и для других прикладных задач, связанных с регистрацией информации.",
                Price = 40000,
                CategoryId = 10,
                OwnerId = USER_ID_3,
                Status = AdvertisementStatus.Active,
                Address = ADDR_3,
                RegionId = 7,
                CreatedAt = DateTime.UtcNow,
            },
            new Advertisement
            {
                Id = 20,
                Title = "Куплю магнитофон",
                Body = "Магнитофон (от магнит и греч. φωνή звук) — электромеханическое устройство, предназначенное для записи звуковой информации на магнитные носители и/или её воспроизведения. В качестве носителя используются материалы с магнитными свойствами: магнитная лента, проволока, магнитные манжеты, диски, барабаны и т. д.",
                Price = 2000,
                CategoryId = 10,
                OwnerId = USER_ID_2,
                Status = AdvertisementStatus.Active,
                Address = ADDR_2,
                RegionId = 8,
                CreatedAt = DateTime.UtcNow,
            },
            new Advertisement
            {
                Id = 21,
                Title = "Стиральная машина",
                Body = "Примитивные стиральные машины представляли собой деревянный ящик с подвижной рамой. Первая стиральная машина, запущенная в серийное производство, была создана в 1907 году[источник не указан 109 дней] Уильямом Блекстоуном, у неё был ручной привод (есть также мнение, что первую сделал Натаниэл Бриггс (Nathaniel Briggs)). В Европе первые стиральные машины начали производить в Германии в 1900 г. Современные машины с электрическим приводом появились в 1904 году[1]. Механизация труда практически привела к исчезновению профессии прачки. В 1949 году в США появилась первая автоматическая стиральная машина.",
                Price = 2000,
                CategoryId = 9,
                OwnerId = USER_ID_1,
                Status = AdvertisementStatus.Active,
                Address = ADDR_1,
                RegionId = 6,
                CreatedAt = DateTime.UtcNow,
            },
        };

        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            builder.HasKey(adv => adv.Id);
            builder.Property(adv => adv.CreatedAt).IsRequired();
            builder.Property(adv => adv.UpdatedAt).IsRequired(false);
            builder.Property(adv => adv.Price).HasColumnType("money");
            builder.HasMany(adv => adv.Tags)
                .WithMany(t => t.Advertisements)
                .UsingEntity(j => j.ToTable("TagAdvertisement"));
            builder.HasOne(adv => adv.Region)
                .WithMany(r => r.Advertisements);
            builder.HasData(advertisements);
        }
    }
}