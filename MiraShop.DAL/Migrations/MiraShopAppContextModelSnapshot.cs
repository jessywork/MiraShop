﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiraShop.DAL;

#nullable disable

namespace MiraShop.DAL.Migrations
{
    [DbContext(typeof(MiraShopAppContext))]
    partial class MiraShopAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MiraShop.DAL.Models.BaseEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("MiraShop.DAL.Models.Cart", b =>
                {
                    b.HasBaseType("MiraShop.DAL.Models.BaseEntity");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("MiraShop.DAL.Models.CartProduct", b =>
                {
                    b.HasBaseType("MiraShop.DAL.Models.BaseEntity");

                    b.Property<Guid>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasIndex("ProductId");

                    b.HasIndex("CartId", "ProductId")
                        .IsUnique()
                        .HasFilter("[CartId] IS NOT NULL AND [ProductId] IS NOT NULL");

                    b.ToTable("CartProducts");
                });

            modelBuilder.Entity("MiraShop.DAL.Models.Category", b =>
                {
                    b.HasBaseType("MiraShop.DAL.Models.BaseEntity");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MiraShop.DAL.Models.FavList", b =>
                {
                    b.HasBaseType("MiraShop.DAL.Models.BaseEntity");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("FavLists");
                });

            modelBuilder.Entity("MiraShop.DAL.Models.FavListProduct", b =>
                {
                    b.HasBaseType("MiraShop.DAL.Models.BaseEntity");

                    b.Property<Guid>("FavListId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("ProductId");

                    b.HasIndex("FavListId", "ProductId")
                        .IsUnique()
                        .HasFilter("[FavListId] IS NOT NULL AND [ProductId] IS NOT NULL");

                    b.ToTable("FavListProducts");
                });

            modelBuilder.Entity("MiraShop.DAL.Models.Genre", b =>
                {
                    b.HasBaseType("MiraShop.DAL.Models.BaseEntity");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("MiraShop.DAL.Models.Order", b =>
                {
                    b.HasBaseType("MiraShop.DAL.Models.BaseEntity");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MiraShop.DAL.Models.OrderProduct", b =>
                {
                    b.HasBaseType("MiraShop.DAL.Models.BaseEntity");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasIndex("ProductId");

                    b.HasIndex("OrderId", "ProductId")
                        .IsUnique()
                        .HasFilter("[OrderId] IS NOT NULL AND [ProductId] IS NOT NULL");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("MiraShop.DAL.Models.Product", b =>
                {
                    b.HasBaseType("MiraShop.DAL.Models.BaseEntity");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GenreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasIndex("CategoryId");

                    b.HasIndex("GenreId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MiraShop.DAL.Models.User", b =>
                {
                    b.HasBaseType("MiraShop.DAL.Models.BaseEntity");

                    b.Property<Guid>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("FavListId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MiraShop.DAL.Models.Cart", b =>
                {
                    b.HasOne("MiraShop.DAL.Models.User", "User")
                        .WithOne("Cart")
                        .HasForeignKey("MiraShop.DAL.Models.Cart", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MiraShop.DAL.Models.CartProduct", b =>
                {
                    b.HasOne("MiraShop.DAL.Models.Cart", "Cart")
                        .WithMany("CartProducts")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiraShop.DAL.Models.Product", "Product")
                        .WithMany("CartProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MiraShop.DAL.Models.FavList", b =>
                {
                    b.HasOne("MiraShop.DAL.Models.User", "User")
                        .WithOne("FavList")
                        .HasForeignKey("MiraShop.DAL.Models.FavList", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MiraShop.DAL.Models.FavListProduct", b =>
                {
                    b.HasOne("MiraShop.DAL.Models.FavList", "FavList")
                        .WithMany("FavListProducts")
                        .HasForeignKey("FavListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiraShop.DAL.Models.Product", "Product")
                        .WithMany("FavListProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FavList");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MiraShop.DAL.Models.Order", b =>
                {
                    b.HasOne("MiraShop.DAL.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MiraShop.DAL.Models.OrderProduct", b =>
                {
                    b.HasOne("MiraShop.DAL.Models.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiraShop.DAL.Models.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MiraShop.DAL.Models.Product", b =>
                {
                    b.HasOne("MiraShop.DAL.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiraShop.DAL.Models.Genre", "Genre")
                        .WithMany("Products")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("MiraShop.DAL.Models.Cart", b =>
                {
                    b.Navigation("CartProducts");
                });

            modelBuilder.Entity("MiraShop.DAL.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("MiraShop.DAL.Models.FavList", b =>
                {
                    b.Navigation("FavListProducts");
                });

            modelBuilder.Entity("MiraShop.DAL.Models.Genre", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("MiraShop.DAL.Models.Order", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("MiraShop.DAL.Models.Product", b =>
                {
                    b.Navigation("CartProducts");

                    b.Navigation("FavListProducts");

                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("MiraShop.DAL.Models.User", b =>
                {
                    b.Navigation("Cart");

                    b.Navigation("FavList");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
