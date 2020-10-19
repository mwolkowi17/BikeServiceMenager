using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeServiceMenager.Data.Migrations
{
    public partial class newactiontodo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "ActionToDo1ServiceActionId",
                table: "ServiceOrders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ActionToDo2ServiceActionId",
                table: "ServiceOrders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ActionToDo3ServiceActionId",
                table: "ServiceOrders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ActionToDo4ServiceActionId",
                table: "ServiceOrders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ActionToDo5ServiceActionId",
                table: "ServiceOrders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AditionalNotes",
                table: "ServiceOrders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrders_ActionToDo1ServiceActionId",
                table: "ServiceOrders",
                column: "ActionToDo1ServiceActionId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrders_ActionToDo2ServiceActionId",
                table: "ServiceOrders",
                column: "ActionToDo2ServiceActionId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrders_ActionToDo3ServiceActionId",
                table: "ServiceOrders",
                column: "ActionToDo3ServiceActionId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrders_ActionToDo4ServiceActionId",
                table: "ServiceOrders",
                column: "ActionToDo4ServiceActionId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrders_ActionToDo5ServiceActionId",
                table: "ServiceOrders",
                column: "ActionToDo5ServiceActionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrders_ServiceActions_ActionToDo1ServiceActionId",
                table: "ServiceOrders",
                column: "ActionToDo1ServiceActionId",
                principalTable: "ServiceActions",
                principalColumn: "ServiceActionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrders_ServiceActions_ActionToDo2ServiceActionId",
                table: "ServiceOrders",
                column: "ActionToDo2ServiceActionId",
                principalTable: "ServiceActions",
                principalColumn: "ServiceActionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrders_ServiceActions_ActionToDo3ServiceActionId",
                table: "ServiceOrders",
                column: "ActionToDo3ServiceActionId",
                principalTable: "ServiceActions",
                principalColumn: "ServiceActionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrders_ServiceActions_ActionToDo4ServiceActionId",
                table: "ServiceOrders",
                column: "ActionToDo4ServiceActionId",
                principalTable: "ServiceActions",
                principalColumn: "ServiceActionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrders_ServiceActions_ActionToDo5ServiceActionId",
                table: "ServiceOrders",
                column: "ActionToDo5ServiceActionId",
                principalTable: "ServiceActions",
                principalColumn: "ServiceActionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrders_ServiceActions_ActionToDo1ServiceActionId",
                table: "ServiceOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrders_ServiceActions_ActionToDo2ServiceActionId",
                table: "ServiceOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrders_ServiceActions_ActionToDo3ServiceActionId",
                table: "ServiceOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrders_ServiceActions_ActionToDo4ServiceActionId",
                table: "ServiceOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrders_ServiceActions_ActionToDo5ServiceActionId",
                table: "ServiceOrders");

            migrationBuilder.DropIndex(
                name: "IX_ServiceOrders_ActionToDo1ServiceActionId",
                table: "ServiceOrders");

            migrationBuilder.DropIndex(
                name: "IX_ServiceOrders_ActionToDo2ServiceActionId",
                table: "ServiceOrders");

            migrationBuilder.DropIndex(
                name: "IX_ServiceOrders_ActionToDo3ServiceActionId",
                table: "ServiceOrders");

            migrationBuilder.DropIndex(
                name: "IX_ServiceOrders_ActionToDo4ServiceActionId",
                table: "ServiceOrders");

            migrationBuilder.DropIndex(
                name: "IX_ServiceOrders_ActionToDo5ServiceActionId",
                table: "ServiceOrders");

            migrationBuilder.DropColumn(
                name: "ActionToDo1ServiceActionId",
                table: "ServiceOrders");

            migrationBuilder.DropColumn(
                name: "ActionToDo2ServiceActionId",
                table: "ServiceOrders");

            migrationBuilder.DropColumn(
                name: "ActionToDo3ServiceActionId",
                table: "ServiceOrders");

            migrationBuilder.DropColumn(
                name: "ActionToDo4ServiceActionId",
                table: "ServiceOrders");

            migrationBuilder.DropColumn(
                name: "ActionToDo5ServiceActionId",
                table: "ServiceOrders");

            migrationBuilder.DropColumn(
                name: "AditionalNotes",
                table: "ServiceOrders");

            migrationBuilder.AddColumn<int>(
                name: "ServiceOrderId",
                table: "ServiceActions",
                type: "int",
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
    }
}
