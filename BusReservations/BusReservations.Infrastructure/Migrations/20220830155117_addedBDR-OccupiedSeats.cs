using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusReservations.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedBDROccupiedSeats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_DrivenRoutes_DrivenRouteId",
                table: "Seats");

            migrationBuilder.RenameColumn(
                name: "DrivenRouteId",
                table: "Seats",
                newName: "BusDrivenRouteId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_DrivenRouteId",
                table: "Seats",
                newName: "IX_Seats_BusDrivenRouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_BusDrivenRoutes_BusDrivenRouteId",
                table: "Seats",
                column: "BusDrivenRouteId",
                principalTable: "BusDrivenRoutes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_BusDrivenRoutes_BusDrivenRouteId",
                table: "Seats");

            migrationBuilder.RenameColumn(
                name: "BusDrivenRouteId",
                table: "Seats",
                newName: "DrivenRouteId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_BusDrivenRouteId",
                table: "Seats",
                newName: "IX_Seats_DrivenRouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_DrivenRoutes_DrivenRouteId",
                table: "Seats",
                column: "DrivenRouteId",
                principalTable: "DrivenRoutes",
                principalColumn: "Id");
        }
    }
}
