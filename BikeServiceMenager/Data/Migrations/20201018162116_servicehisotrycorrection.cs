using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeServiceMenager.Data.Migrations
{
    public partial class servicehisotrycorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceHistories_ServiceActions_ServiceActionHistoryServiceActionId",
                table: "ServiceHistories");

            migrationBuilder.DropIndex(
                name: "IX_ServiceHistories_ServiceActionHistoryServiceActionId",
                table: "ServiceHistories");

            migrationBuilder.DropColumn(
                name: "ServiceActionHistoryServiceActionId",
                table: "ServiceHistories");

            migrationBuilder.AddColumn<int>(
                name: "ServiceOrderHistoryServiceOrderId",
                table: "ServiceHistories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHistories_ServiceOrderHistoryServiceOrderId",
                table: "ServiceHistories",
                column: "ServiceOrderHistoryServiceOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceHistories_ServiceOrders_ServiceOrderHistoryServiceOrderId",
                table: "ServiceHistories",
                column: "ServiceOrderHistoryServiceOrderId",
                principalTable: "ServiceOrders",
                principalColumn: "ServiceOrderId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceHistories_ServiceOrders_ServiceOrderHistoryServiceOrderId",
                table: "ServiceHistories");

            migrationBuilder.DropIndex(
                name: "IX_ServiceHistories_ServiceOrderHistoryServiceOrderId",
                table: "ServiceHistories");

            migrationBuilder.DropColumn(
                name: "ServiceOrderHistoryServiceOrderId",
                table: "ServiceHistories");

            migrationBuilder.AddColumn<int>(
                name: "ServiceActionHistoryServiceActionId",
                table: "ServiceHistories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHistories_ServiceActionHistoryServiceActionId",
                table: "ServiceHistories",
                column: "ServiceActionHistoryServiceActionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceHistories_ServiceActions_ServiceActionHistoryServiceActionId",
                table: "ServiceHistories",
                column: "ServiceActionHistoryServiceActionId",
                principalTable: "ServiceActions",
                principalColumn: "ServiceActionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
