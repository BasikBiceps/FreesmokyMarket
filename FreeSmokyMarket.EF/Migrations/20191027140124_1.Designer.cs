﻿// <auto-generated />
using System;
using FreeSmokyMarket.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FreeSmokyMarket.EF.Migrations
{
    [DbContext(typeof(FreeSmokyMarketContext))]
    [Migration("20191027140124_1")]
    partial class _1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FreeSmokyMarket.Data.Entities.Basket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SessionId");

                    b.Property<DateTime>("SessionStart");

                    b.HasKey("Id");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("FreeSmokyMarket.Data.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandName");

                    b.Property<int?>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("FreeSmokyMarket.Data.Entities.ConcreteProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<int?>("BasketId");

                    b.Property<int?>("BrandId");

                    b.Property<string>("Description");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<byte[]>("ProductPicture");

                    b.HasKey("Id");

                    b.HasIndex("BasketId");

                    b.HasIndex("BrandId");

                    b.ToTable("ConcreteProducts");
                });

            modelBuilder.Entity("FreeSmokyMarket.Data.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<int?>("BasketId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("OrderDate");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("OrderId");

                    b.HasIndex("BasketId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FreeSmokyMarket.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProductName");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("FreeSmokyMarket.Data.Entities.Brand", b =>
                {
                    b.HasOne("FreeSmokyMarket.Data.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("FreeSmokyMarket.Data.Entities.ConcreteProduct", b =>
                {
                    b.HasOne("FreeSmokyMarket.Data.Entities.Basket", "Basket")
                        .WithMany()
                        .HasForeignKey("BasketId");

                    b.HasOne("FreeSmokyMarket.Data.Entities.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId");
                });

            modelBuilder.Entity("FreeSmokyMarket.Data.Entities.Order", b =>
                {
                    b.HasOne("FreeSmokyMarket.Data.Entities.Basket", "Basket")
                        .WithMany()
                        .HasForeignKey("BasketId");
                });
#pragma warning restore 612, 618
        }
    }
}