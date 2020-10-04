using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeServiceMenager.Data.Migrations
{
    public partial class ServiceOrderClassAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceOrders",
                columns: table => new
                {
                    ServiceOrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BikeToServiceBikeId = table.Column<int>(nullable: true),
                    BikeToServiceOwnerClientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceOrders", x => x.ServiceOrderId);
                    table.ForeignKey(
                        name: "FK_ServiceOrders_Bikes_BikeToServiceBikeId",
                        column: x => x.BikeToServiceBikeId,
                        principalTable: "Bikes",
                        principalColumn: "BikeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceOrders_Clients_BikeToServiceOwnerClientId",
                        column: x => x.BikeToServiceOwnerClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrders_BikeToServiceBikeId",
                table: "ServiceOrders",
                column: "BikeToServiceBikeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrders_BikeToServiceOwnerClientId",
                table: "ServiceOrders",
                column: "BikeToServiceOwnerClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceOrders");
        }
    }
}
