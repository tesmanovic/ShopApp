using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopApp.Migrations
{
    public partial class updatedatabasefixstage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_DCustomerId1",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Order_DOrderId1",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_Customer_DCustomerId1",
                table: "ShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_Stage_Festival_DFestivalId",
                table: "Stage");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Stage_DStageId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_DStageId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Stage_DFestivalId",
                table: "Stage");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCart_DCustomerId1",
                table: "ShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_DOrderId1",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_Order_DCustomerId1",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DStageId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "DFestivalId",
                table: "Stage");

            migrationBuilder.DropColumn(
                name: "DCustomerId",
                table: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "DCustomerId1",
                table: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "DOrderId",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "DOrderId1",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "DCustomerId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DCustomerId1",
                table: "Order");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DStageId",
                table: "Ticket",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DFestivalId",
                table: "Stage",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DCustomerId",
                table: "ShoppingCart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DCustomerId1",
                table: "ShoppingCart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DOrderId",
                table: "OrderItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DOrderId1",
                table: "OrderItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DCustomerId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DCustomerId1",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_DStageId",
                table: "Ticket",
                column: "DStageId");

            migrationBuilder.CreateIndex(
                name: "IX_Stage_DFestivalId",
                table: "Stage",
                column: "DFestivalId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_DCustomerId1",
                table: "ShoppingCart",
                column: "DCustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_DOrderId1",
                table: "OrderItem",
                column: "DOrderId1");

            migrationBuilder.CreateIndex(
                name: "IX_Order_DCustomerId1",
                table: "Order",
                column: "DCustomerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_DCustomerId1",
                table: "Order",
                column: "DCustomerId1",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Order_DOrderId1",
                table: "OrderItem",
                column: "DOrderId1",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_Customer_DCustomerId1",
                table: "ShoppingCart",
                column: "DCustomerId1",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stage_Festival_DFestivalId",
                table: "Stage",
                column: "DFestivalId",
                principalTable: "Festival",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Stage_DStageId",
                table: "Ticket",
                column: "DStageId",
                principalTable: "Stage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
