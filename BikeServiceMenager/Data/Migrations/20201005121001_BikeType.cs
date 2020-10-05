using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeServiceMenager.Data.Migrations
{
    public partial class BikeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfOrderOpen",
                table: "ServiceOrders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Bikes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfOrderOpen",
                table: "ServiceOrders");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Bikes");
        }
    }
}
