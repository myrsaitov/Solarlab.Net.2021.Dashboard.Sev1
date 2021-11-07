﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sev1.Advertisements.DataAccess;

namespace Advertisements.DataAccess.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AdvertisementTag", b =>
                {
                    b.Property<int>("AdvertisementsId")
                        .HasColumnType("int");

                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.HasKey("AdvertisementsId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("TagAdvertisement");
                });

            modelBuilder.Entity("Sev1.Advertisements.Domain.Advertisement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Advertisements");
                });

            modelBuilder.Entity("Sev1.Advertisements.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(2888),
                            IsDeleted = false,
                            Name = "Транспорт"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3398),
                            IsDeleted = false,
                            Name = "Автомобили",
                            ParentCategoryId = 1
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3641),
                            IsDeleted = false,
                            Name = "Мотоциклы и мототехника",
                            ParentCategoryId = 1
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3644),
                            IsDeleted = false,
                            Name = "Грузовики и спецтехника",
                            ParentCategoryId = 1
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3645),
                            IsDeleted = false,
                            Name = "Недвижимость"
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3877),
                            IsDeleted = false,
                            Name = "Квартиры",
                            ParentCategoryId = 5
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3879),
                            IsDeleted = false,
                            Name = "Комнаты",
                            ParentCategoryId = 5
                        },
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3880),
                            IsDeleted = false,
                            Name = "Дома, дачи, коттеджи",
                            ParentCategoryId = 5
                        },
                        new
                        {
                            Id = 9,
                            CreatedAt = new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3881),
                            IsDeleted = false,
                            Name = "Электроника"
                        },
                        new
                        {
                            Id = 10,
                            CreatedAt = new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3882),
                            IsDeleted = false,
                            Name = "Аудио и видео",
                            ParentCategoryId = 9
                        },
                        new
                        {
                            Id = 11,
                            CreatedAt = new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3883),
                            IsDeleted = false,
                            Name = "Игры, приставки и программы",
                            ParentCategoryId = 9
                        },
                        new
                        {
                            Id = 12,
                            CreatedAt = new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3884),
                            IsDeleted = false,
                            Name = "Настольные компьютеры",
                            ParentCategoryId = 9
                        },
                        new
                        {
                            Id = 13,
                            CreatedAt = new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3885),
                            IsDeleted = false,
                            Name = "Ноутбуки",
                            ParentCategoryId = 9
                        },
                        new
                        {
                            Id = 14,
                            CreatedAt = new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3886),
                            IsDeleted = false,
                            Name = "Планшеты и электронные книги",
                            ParentCategoryId = 9
                        },
                        new
                        {
                            Id = 15,
                            CreatedAt = new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3887),
                            IsDeleted = false,
                            Name = "Телефоны",
                            ParentCategoryId = 9
                        },
                        new
                        {
                            Id = 16,
                            CreatedAt = new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3888),
                            IsDeleted = false,
                            Name = "Товары для компьютера",
                            ParentCategoryId = 9
                        },
                        new
                        {
                            Id = 17,
                            CreatedAt = new DateTime(2021, 11, 7, 20, 25, 6, 262, DateTimeKind.Utc).AddTicks(3889),
                            IsDeleted = false,
                            Name = "Фототехника",
                            ParentCategoryId = 9
                        });
                });

            modelBuilder.Entity("Sev1.Advertisements.Domain.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("AdvertisementTag", b =>
                {
                    b.HasOne("Sev1.Advertisements.Domain.Advertisement", null)
                        .WithMany()
                        .HasForeignKey("AdvertisementsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sev1.Advertisements.Domain.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sev1.Advertisements.Domain.Advertisement", b =>
                {
                    b.HasOne("Sev1.Advertisements.Domain.Category", "Category")
                        .WithMany("Advertisements")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Sev1.Advertisements.Domain.Category", b =>
                {
                    b.HasOne("Sev1.Advertisements.Domain.Category", "ParentCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("Sev1.Advertisements.Domain.Category", b =>
                {
                    b.Navigation("Advertisements");

                    b.Navigation("ChildCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
