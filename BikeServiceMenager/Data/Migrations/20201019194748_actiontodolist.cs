using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeServiceMenager.Data.Migrations
{
    public partial class actiontodolist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceOrderId",
                table: "ServiceActions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceActions_ServiceOrderId",
                table: "ServiceActions",
                column: "ServiceOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceActions_ServiceOrders_ServiceOrderId",
                table: "ServiceActions",
                column: "ServiceOrderId",
                principalTable: "ServiceOrders",
                principalColumn: "ServiceOrderId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceActions_ServiceOrders_ServiceOrderId",
                table: "ServiceActions");

            migrationBuilder.DropIndex(
                name: "IX_ServiceActions_ServiceOrderId",
                table: "ServiceActions");

            migrationBuilder.DropColumn(
                name: "ServiceOrderId",
                table: "ServiceActions");
        }
    }
}
