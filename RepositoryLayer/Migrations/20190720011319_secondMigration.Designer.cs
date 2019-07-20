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
    [Migration("20190720011319_secondMigration")]
    partial class secondMigration
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

                    b.Property<Guid?>("ProductID");

                    b.Property<int>("Quantity");

                    b.Property<Guid?>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("ProductID");

                    b.HasIndex("UserID");

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

                    b.Property<Guid?>("CartID");

                    b.Property<Guid?>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("CartID");

                    b.HasIndex("UserID");

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
                            ID = new Guid("a5aad81d-4c5f-4b47-82cd-7e573bc486a9"),
                            Description = "this is the first product",
                            Price = 100.0,
                            ProductName = "P1",
                            Quantity = 5.0
                        },
                        new
                        {
                            ID = new Guid("681a08da-9489-46e3-b629-5fa7f027b86d"),
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
                            ID = new Guid("1856298f-bce6-4477-9e67-c05a834a9d44"),
                            Name = "Basma"
                        },
                        new
                        {
                            ID = new Guid("9f28cc0a-85d7-4ee3-ba7c-d6aeb5c3e2e1"),
                            Name = "Ola"
                        });
                });

            modelBuilder.Entity("DataLayer.Cart", b =>
                {
                    b.HasOne("DataLayer.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID");

                    b.HasOne("DataLayer.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");
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
                        .HasForeignKey("CartID");

                    b.HasOne("DataLayer.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");
                });
#pragma warning restore 612, 618
        }
    }
}