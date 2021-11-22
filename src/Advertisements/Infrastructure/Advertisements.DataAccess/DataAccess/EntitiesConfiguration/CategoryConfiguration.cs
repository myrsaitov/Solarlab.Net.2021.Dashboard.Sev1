using System;
using Sev1.Advertisements.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sev1.Advertisements.DataAccess.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        // Группа 1 - "Транспорт"
        private static Category category1 = new Category
        {
            Id = 1,
            Name = "Транспорт",
            CreatedAt = DateTime.UtcNow,
            IsDeleted = false,
            ParentCategory = null
        };

        private static Category category1_1 = new Category
        {
            Id = 2,
            Name = "Автомобили",
            CreatedAt = DateTime.UtcNow,
            IsDeleted = false,
            ParentCategoryId = 1
        };

        private static Category category1_2 = new Category
        {
            Id = 3,
            Name = "Мотоциклы и мототехника",
            CreatedAt = DateTime.UtcNow,
            IsDeleted = false,
            ParentCategoryId = 1
        };

        private static Category category1_3 = new Category
        {
            Id = 4,
            Name = "Грузовики и спецтехника",
            CreatedAt = DateTime.UtcNow,
            IsDeleted = false,
            ParentCategoryId = 1
        };

        // Группа 2 - "Недвижимость"
        private static Category category2 = new Category
        {
            Id = 5,
            Name = "Недвижимость",
            CreatedAt = DateTime.UtcNow,
            IsDeleted = false,
            ParentCategory = null
        };

        private static Category category2_1 = new Category
        {
            Id = 6,
            Name = "Квартиры",
            CreatedAt = DateTime.UtcNow,
            IsDeleted = false,
            ParentCategoryId = 5
        };

        private static Category category2_2 = new Category
        {
            Id = 7,
            Name = "Комнаты",
            CreatedAt = DateTime.UtcNow,
            IsDeleted = false,
            ParentCategoryId = 5
        };

        private static Category category2_3 = new Category
        {
            Id = 8,
            Name = "Дома, дачи, коттеджи",
            CreatedAt = DateTime.UtcNow,
            IsDeleted = false,
            ParentCategoryId = 5
        };

        // Группа 3 - "Электроника"
        private static Category category3 = new Category
        {
            Id = 9,
            Name = "Электроника",
            CreatedAt = DateTime.UtcNow,
            IsDeleted = false,
            ParentCategory = null
        };

        private static Category category3_1 = new Category
        {
            Id = 10,
            Name = "Аудио и видео",
            CreatedAt = DateTime.UtcNow,
            IsDeleted = false,
            ParentCategoryId = 9
        };
        private static Category category3_2 = new Category
        {
            Id = 11,
            Name = "Игры, приставки и программы",
            CreatedAt = DateTime.UtcNow,
            IsDeleted = false,
            ParentCategoryId = 9
        };
        private static Category category3_3 = new Category
        {
            Id = 12,
            Name = "Настольные компьютеры",
            CreatedAt = DateTime.UtcNow,
            IsDeleted = false,
            ParentCategoryId = 9
        };
        private static Category category3_4 = new Category
        {
            Id = 13,
            Name = "Ноутбуки",
            CreatedAt = DateTime.UtcNow,
            IsDeleted = false,
            ParentCategoryId = 9
        };
        private static Category category3_5 = new Category
        {
            Id = 14,
            Name = "Планшеты и электронные книги",
            CreatedAt = DateTime.UtcNow,
            IsDeleted = false,
            ParentCategoryId = 9
        };
        private static Category category3_6 = new Category
        {
            Id = 15,
            Name = "Телефоны",
            CreatedAt = DateTime.UtcNow,
            IsDeleted = false,
            ParentCategoryId = 9
        };
        private static Category category3_7 = new Category
        {
            Id = 16,
            Name = "Товары для компьютера",
            CreatedAt = DateTime.UtcNow,
            IsDeleted = false,
            ParentCategoryId = 9
        };
        private static Category category3_8 = new Category
        {
            Id = 17,
            Name = "Фототехника",
            CreatedAt = DateTime.UtcNow,
            IsDeleted = false,
            ParentCategoryId = 9
        };

        private readonly Category[] categories = new Category[]
        {
            category1,
            category1_1,
            category1_2,
            category1_3,
            category2,
            category2_1,
            category2_2,
            category2_3,
            category3,
            category3_1,
            category3_2,
            category3_3,
            category3_4,
            category3_5,
            category3_6,
            category3_7,
            category3_8
        };
        
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(cat => cat.Id);
            builder.Property(cat => cat.Name).IsRequired();
            builder.Property(cat => cat.ParentCategoryId).IsRequired(false);
            builder.Property(cat => cat.CreatedAt).IsRequired();
            builder.Property(cat => cat.UpdatedAt).IsRequired(false);
            builder.HasData(categories);
        }
    }
}