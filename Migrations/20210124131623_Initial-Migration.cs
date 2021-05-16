using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopApp.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    Password = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    FirstName = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    LastName = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    Email = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    Address = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    BillingAddress = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    OpenDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Festival",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(100)", nullable: true),
                    Description = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    DateFrom = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Festival", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "NVARCHAR(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    DCustomerId = table.Column<int>(type: "int", nullable: false),
                    DCustomerId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShoppingCart_Customer_DCustomerId1",
                        column: x => x.DCustomerId1,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(100)", nullable: true),
                    Description = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    FestivalId = table.Column<int>(type: "int", nullable: false),
                    DFestivalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stage_Festival_DFestivalId",
                        column: x => x.DFestivalId,
                        principalTable: "Festival",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stage_Festival_FestivalId",
                        column: x => x.FestivalId,
                        principalTable: "Festival",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillingAddress = table.Column<string>(type: "NVARCHAR(150)", nullable: true),
                    OpenDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false),
                    DCustomerId = table.Column<int>(type: "int", nullable: false),
                    DCustomerId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_Customer_DCustomerId1",
                        column: x => x.DCustomerId1,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_OrderStatus_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    StageId = table.Column<int>(type: "int", nullable: true),
                    DStageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Stage_DStageId",
                        column: x => x.DStageId,
                        principalTable: "Stage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Stage_StageId",
                        column: x => x.StageId,
                        principalTable: "Stage",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaidDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    DCustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Payment_Customer_DCustomerId",
                        column: x => x.DCustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payment_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<int>(type: "INT", nullable: false),
                    Amount = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    DOrderId = table.Column<int>(type: "int", nullable: false),
                    DOrderId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_DOrderId1",
                        column: x => x.DOrderId1,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItem_ShoppingCart_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCart",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItem_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_DCustomerId1",
                table: "Order",
                column: "DCustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderStatusId",
                table: "Order",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_DOrderId1",
                table: "OrderItem",
                column: "DOrderId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ShoppingCartId",
                table: "OrderItem",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_TicketId",
                table: "OrderItem",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CustomerId",
                table: "Payment",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_DCustomerId",
                table: "Payment",
                column: "DCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_OrderId",
                table: "Payment",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_CustomerId",
                table: "ShoppingCart",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_DCustomerId1",
                table: "ShoppingCart",
                column: "DCustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Stage_DFestivalId",
                table: "Stage",
                column: "DFestivalId");

            migrationBuilder.CreateIndex(
                name: "IX_Stage_FestivalId",
                table: "Stage",
                column: "FestivalId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_DStageId",
                table: "Ticket",
                column: "DStageId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_StageId",
                table: "Ticket",
                column: "StageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Stage");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "Festival");
        }
    }
}
