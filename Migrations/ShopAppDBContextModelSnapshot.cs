﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopApp.Models;

namespace ShopApp.Migrations
{
    [DbContext(typeof(ShopAppDBContext))]
    partial class ShopAppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ShopApp.Models.DCustomer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("BillingAddress")
                        .HasColumnType("NVARCHAR(MAX)");

                    b.Property<DateTime>("CloseDate")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Email")
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("FirstName")
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("LastName")
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<DateTime>("OpenDate")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Password")
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("Username")
                        .HasColumnType("NVARCHAR(50)");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("ShopApp.Models.DFestival", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Description")
                        .HasColumnType("NVARCHAR(MAX)");

                    b.Property<string>("ImageName")
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<string>("Name")
                        .HasColumnType("NVARCHAR(100)");

                    b.HasKey("Id");

                    b.ToTable("Festival");
                });

            modelBuilder.Entity("ShopApp.Models.DOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("BillingAddress")
                        .HasColumnType("NVARCHAR(150)");

                    b.Property<DateTime>("CloseDate")
                        .HasColumnType("DATETIME");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OpenDate")
                        .HasColumnType("DATETIME");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("DECIMAL(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OrderStatusId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("ShopApp.Models.DOrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("Amount")
                        .HasColumnType("DECIMAL(18,2)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("INT");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("TicketId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("ShopApp.Models.DOrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("NVARCHAR(20)");

                    b.HasKey("Id");

                    b.ToTable("OrderStatus");
                });

            modelBuilder.Entity("ShopApp.Models.DPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaidDate")
                        .HasColumnType("DATETIME");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("DECIMAL(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OrderId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("ShopApp.Models.DShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("DATETIME");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("ShoppingCart");
                });

            modelBuilder.Entity("ShopApp.Models.DStage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("NVARCHAR(MAX)");

                    b.Property<int>("FestivalId")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<string>("Name")
                        .HasColumnType("NVARCHAR(100)");

                    b.HasKey("Id");

                    b.HasIndex("FestivalId");

                    b.ToTable("Stage");
                });

            modelBuilder.Entity("ShopApp.Models.DTicket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("DATETIME");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(18,2)");

                    b.Property<int?>("StageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StageId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("ShopApp.Models.DOrder", b =>
                {
                    b.HasOne("ShopApp.Models.DCustomer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ShopApp.Models.DOrderStatus", "OrderStatus")
                        .WithMany()
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("OrderStatus");
                });

            modelBuilder.Entity("ShopApp.Models.DOrderItem", b =>
                {
                    b.HasOne("ShopApp.Models.DOrder", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ShopApp.Models.DTicket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Order");


                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("ShopApp.Models.DPayment", b =>
                {
                    b.HasOne("ShopApp.Models.DCustomer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ShopApp.Models.DOrder", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("ShopApp.Models.DShoppingCart", b =>
                {
                    b.HasOne("ShopApp.Models.DCustomer", "Customer")
                        .WithMany("ShoppingCarts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ShopApp.Models.DStage", b =>
                {
                    b.HasOne("ShopApp.Models.DFestival", "Festival")
                        .WithMany("Stages")
                        .HasForeignKey("FestivalId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Festival");
                });

            modelBuilder.Entity("ShopApp.Models.DTicket", b =>
                {
                    b.HasOne("ShopApp.Models.DStage", "Stage")
                        .WithMany("Tickets")
                        .HasForeignKey("StageId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Stage");
                });

            modelBuilder.Entity("ShopApp.Models.DCustomer", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Payments");

                    b.Navigation("ShoppingCarts");
                });

            modelBuilder.Entity("ShopApp.Models.DFestival", b =>
                {
                    b.Navigation("Stages");
                    b.Navigation("Stages");
                });

            modelBuilder.Entity("ShopApp.Models.DOrder", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("ShopApp.Models.DStage", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
