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
                .HasAnnotation("ProductVersion", "5.0.9")
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

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

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
                            CreatedAt = new DateTime(2021, 9, 6, 6, 16, 12, 666, DateTimeKind.Utc).AddTicks(6887),
                            IsDeleted = false,
                            Name = "Транспорт"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2021, 9, 6, 6, 16, 12, 666, DateTimeKind.Utc).AddTicks(8607),
                            IsDeleted = false,
                            Name = "Недвижимость"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2021, 9, 6, 6, 16, 12, 666, DateTimeKind.Utc).AddTicks(8613),
                            IsDeleted = false,
                            Name = "Мебель"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2021, 9, 6, 6, 16, 12, 666, DateTimeKind.Utc).AddTicks(8640),
                            IsDeleted = false,
                            Name = "Одежда"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2021, 9, 6, 6, 16, 12, 666, DateTimeKind.Utc).AddTicks(8642),
                            IsDeleted = false,
                            Name = "Бытовая техника"
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2021, 9, 6, 6, 16, 12, 666, DateTimeKind.Utc).AddTicks(8644),
                            IsDeleted = false,
                            Name = "Книги"
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
