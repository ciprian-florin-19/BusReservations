using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusReservations.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSeatModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Seat_SeatInfoSeatId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_DrivenRoutes_DrivenRouteId",
                table: "Seat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seat",
                table: "Seat");

            migrationBuilder.RenameTable(
                name: "Seat",
                newName: "Seats");

            migrationBuilder.RenameColumn(
                name: "SeatInfoSeatId",
                table: "Reservations",
                newName: "SeatId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_SeatInfoSeatId",
                table: "Reservations",
                newName: "IX_Reservations_SeatId");

            migrationBuilder.RenameColumn(
                name: "SeatId",
                table: "Seats",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_DrivenRouteId",
                table: "Seats",
                newName: "IX_Seats_DrivenRouteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seats",
                table: "Seats",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Seats_SeatId",
                table: "Reservations",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_DrivenRoutes_DrivenRouteId",
                table: "Seats",
                column: "DrivenRouteId",
                principalTable: "DrivenRoutes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Seats_SeatId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_DrivenRoutes_DrivenRouteId",
                table: "Seats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seats",
                table: "Seats");

            migrationBuilder.RenameTable(
                name: "Seats",
                newName: "Seat");

            migrationBuilder.RenameColumn(
                name: "SeatId",
                table: "Reservations",
                newName: "SeatInfoSeatId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_SeatId",
                table: "Reservations",
                newName: "IX_Reservations_SeatInfoSeatId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Seat",
                newName: "SeatId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_DrivenRouteId",
                table: "Seat",
                newName: "IX_Seat_DrivenRouteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seat",
                table: "Seat",
                column: "SeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Seat_SeatInfoSeatId",
                table: "Reservations",
                column: "SeatInfoSeatId",
                principalTable: "Seat",
                principalColumn: "SeatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_DrivenRoutes_DrivenRouteId",
                table: "Seat",
                column: "DrivenRouteId",
                principalTable: "DrivenRoutes",
                principalColumn: "Id");
        }
    }
}
