﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Samat.Infrastructure.EfPersistance;

#nullable disable

namespace Samat.Infrastructure.EfPersistance.Migrations
{
    [DbContext(typeof(SamatDbContext))]
    partial class SamatDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Samat.Domains.Customers.Customer", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("LastPurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NationalCode")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("Samat.Domains.Orders.Entities.OrderItem", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem", (string)null);
                });

            modelBuilder.Entity("Samat.Domains.Orders.Order", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("Samat.Domains.Products.Product", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("Samat.Domains.Orders.Entities.OrderItem", b =>
                {
                    b.HasOne("Samat.Domains.Orders.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Samat.Domains.Orders.ValueObjects.Product", "ProductId", b1 =>
                        {
                            b1.Property<long>("OrderItemId")
                                .HasColumnType("bigint");

                            b1.Property<long>("Id")
                                .HasColumnType("bigint")
                                .HasColumnName("ProductId");

                            b1.HasKey("OrderItemId");

                            b1.HasIndex("Id");

                            b1.ToTable("OrderItem");

                            b1.HasOne("Samat.Domains.Products.Product", null)
                                .WithMany()
                                .HasForeignKey("Id")
                                .OnDelete(DeleteBehavior.Restrict)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("OrderItemId");
                        });

                    b.Navigation("ProductId")
                        .IsRequired();
                });

            modelBuilder.Entity("Samat.Domains.Orders.Order", b =>
                {
                    b.OwnsOne("Samat.Domains.Orders.ValueObjects.Customer", "CustomerId", b1 =>
                        {
                            b1.Property<long>("OrderId")
                                .HasColumnType("bigint");

                            b1.Property<long>("Id")
                                .HasColumnType("bigint")
                                .HasColumnName("CustomerId");

                            b1.HasKey("OrderId");

                            b1.HasIndex("Id");

                            b1.ToTable("Order");

                            b1.HasOne("Samat.Domains.Customers.Customer", null)
                                .WithMany()
                                .HasForeignKey("Id")
                                .OnDelete(DeleteBehavior.Restrict)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("CustomerId")
                        .IsRequired();
                });

            modelBuilder.Entity("Samat.Domains.Orders.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
