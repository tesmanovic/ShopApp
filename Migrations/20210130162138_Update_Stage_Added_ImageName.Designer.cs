﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopApp.Models;

namespace ShopApp.Migrations
{
    [DbContext(typeof(ShopAppDBContext))]
    [Migration("20210130162138_Update_Stage_Added_ImageName")]
    partial class Update_Stage_Added_ImageName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("DCustomerId")
                        .HasColumnType("int");

                    b.Property<int>("DCustomerId1")
                        .HasColumnType("int");

                    b.Property<DateTime>("OpenDate")
                        .HasColumnType("DATETIME");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("DECIMAL(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DCustomerId1");

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

                    b.Property<int>("DOrderId")
                        .HasColumnType("int");

                    b.Property<int>("DOrderId1")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("INT");

                    b.Property<int>("ShoppingCartId")
                        .HasColumnType("int");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DOrderId1");

                    b.HasIndex("OrderId");

                    b.HasIndex("ShoppingCartId");

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

                    b.Property<int?>("DCustomerId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaidDate")
                        .HasColumnType("DATETIME");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("DECIMAL(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DCustomerId");

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

                    b.Property<int>("DCustomerId")
                        .HasColumnType("int");

                    b.Property<int>("DCustomerId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DCustomerId1");

                    b.ToTable("ShoppingCart");
                });

            modelBuilder.Entity("ShopApp.Models.DStage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("DFestivalId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("NVARCHAR(MAX)");

                    b.Property<int>("FestivalId")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<string>("Name")
                        .HasColumnType("NVARCHAR(100)");

                    b.HasKey("Id");

                    b.HasIndex("DFestivalId");

                    b.HasIndex("FestivalId");

                    b.ToTable("Stage");
                });

            modelBuilder.Entity("ShopApp.Models.DTicket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("DStageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("DATETIME");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(18,2)");

                    b.Property<int?>("StageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DStageId");

                    b.HasIndex("StageId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("ShopApp.Models.DOrder", b =>
                {
                    b.HasOne("ShopApp.Models.DCustomer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ShopApp.Models.DCustomer", null)
                        .WithMany("Orders")
                        .HasForeignKey("DCustomerId1")
                        .OnDelete(DeleteBehavior.Cascade)
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
                    b.HasOne("ShopApp.Models.DOrder", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("DOrderId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopApp.Models.DOrder", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ShopApp.Models.DShoppingCart", "ShoppingCart")
                        .WithMany()
                        .HasForeignKey("ShoppingCartId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ShopApp.Models.DTicket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("ShoppingCart");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("ShopApp.Models.DPayment", b =>
                {
                    b.HasOne("ShopApp.Models.DCustomer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ShopApp.Models.DCustomer", null)
                        .WithMany("Payments")
                        .HasForeignKey("DCustomerId");

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
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ShopApp.Models.DCustomer", null)
                        .WithMany("ShoppingCarts")
                        .HasForeignKey("DCustomerId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ShopApp.Models.DStage", b =>
                {
                    b.HasOne("ShopApp.Models.DFestival", null)
                        .WithMany("Stages")
                        .HasForeignKey("DFestivalId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShopApp.Models.DFestival", "Festival")
                        .WithMany()
                        .HasForeignKey("FestivalId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Festival");
                });

            modelBuilder.Entity("ShopApp.Models.DTicket", b =>
                {
                    b.HasOne("ShopApp.Models.DStage", null)
                        .WithMany("Tickets")
                        .HasForeignKey("DStageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShopApp.Models.DStage", "Stage")
                        .WithMany()
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
