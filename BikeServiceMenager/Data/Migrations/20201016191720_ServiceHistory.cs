using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeServiceMenager.Data.Migrations
{
    public partial class ServiceHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceHistories",
                columns: table => new
                {
                    ServiceHistoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceActionHistoryServiceActionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceHistories", x => x.ServiceHistoryId);
                    table.ForeignKey(
                        name: "FK_ServiceHistories_ServiceActions_ServiceActionHistoryServiceActionId",
                        column: x => x.ServiceActionHistoryServiceActionId,
                        principalTable: "ServiceActions",
                        principalColumn: "ServiceActionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHistories_ServiceActionHistoryServiceActionId",
                table: "ServiceHistories",
                column: "ServiceActionHistoryServiceActionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceHistories");
        }
    }
}
