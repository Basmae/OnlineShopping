﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepositoryLayer;

namespace RepositoryLayer.Migrations
{
    [DbContext(typeof(OnlineShoppingContext))]
    [Migration("20190723193619_firstMigration")]
    partial class firstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataLayer.Cart", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsSubmitted");

                    b.Property<double>("Price");

                    b.Property<Guid>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<Guid>("UserId");

                    b.HasKey("ID");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("DataLayer.Image", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImageUrl")
                        .IsRequired();

                    b.Property<Guid>("ProductId");

                    b.HasKey("ID");

                    b.HasIndex("ProductId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("DataLayer.Order", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CartId");

                    b.Property<Guid>("UserId");

                    b.HasKey("ID");

                    b.HasIndex("CartId");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("DataLayer.Product", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<double>("Price");

                    b.Property<string>("ProductName")
                        .IsRequired();

                    b.Property<double>("Quantity");

                    b.HasKey("ID");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            ID = new Guid("cb24c610-ba72-4b15-814c-aa6eb43d9007"),
                            Description = "this is the first product",
                            Price = 100.0,
                            ProductName = "P1",
                            Quantity = 5.0
                        },
                        new
                        {
                            ID = new Guid("a229e6ce-47ab-44bd-867e-18dab78e550d"),
                            Description = "this is the second product",
                            Price = 200.0,
                            ProductName = "P2",
                            Quantity = 10.0
                        });
                });

            modelBuilder.Entity("DataLayer.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            ID = new Guid("1a8c8375-b7f4-4b59-9c8b-87ca9dd6b992"),
                            Name = "Basma"
                        },
                        new
                        {
                            ID = new Guid("a915dca0-f0d4-4294-a50c-40f28b9cfb9b"),
                            Name = "Ola"
                        });
                });

            modelBuilder.Entity("DataLayer.Cart", b =>
                {
                    b.HasOne("DataLayer.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataLayer.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataLayer.Image", b =>
                {
                    b.HasOne("DataLayer.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataLayer.Order", b =>
                {
                    b.HasOne("DataLayer.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DataLayer.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}