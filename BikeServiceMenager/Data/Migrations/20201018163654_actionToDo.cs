﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeServiceMenager.Data.Migrations
{
    public partial class actionToDo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActionToDoServiceActionId",
                table: "ServiceOrders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrders_ActionToDoServiceActionId",
                table: "ServiceOrders",
                column: "ActionToDoServiceActionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrders_ServiceActions_ActionToDoServiceActionId",
                table: "ServiceOrders",
                column: "ActionToDoServiceActionId",
                principalTable: "ServiceActions",
                principalColumn: "ServiceActionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrders_ServiceActions_ActionToDoServiceActionId",
                table: "ServiceOrders");

            migrationBuilder.DropIndex(
                name: "IX_ServiceOrders_ActionToDoServiceActionId",
                table: "ServiceOrders");

            migrationBuilder.DropColumn(
                name: "ActionToDoServiceActionId",
                table: "ServiceOrders");
        }
    }
}
