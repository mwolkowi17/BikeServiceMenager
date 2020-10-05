using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeServiceMenager.Data.Migrations
{
    public partial class serviceactioncrrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceActions",
                columns: table => new
                {
                    ServiceActionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionName = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    ManHour = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceActions", x => x.ServiceActionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceActions");
        }
    }
}
