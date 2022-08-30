using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusReservations.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedReservationBDR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_DrivenRoutes_DrivenRouteId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_DrivenRouteId",
                table: "Reservations");

            migrationBuilder.AddColumn<Guid>(
                name: "BusDrivenRouteId",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_BusDrivenRouteId",
                table: "Reservations",
                column: "BusDrivenRouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_BusDrivenRoutes_BusDrivenRouteId",
                table: "Reservations",
                column: "BusDrivenRouteId",
                principalTable: "BusDrivenRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_BusDrivenRoutes_BusDrivenRouteId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_BusDrivenRouteId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "BusDrivenRouteId",
                table: "Reservations");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_DrivenRouteId",
                table: "Reservations",
                column: "DrivenRouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_DrivenRoutes_DrivenRouteId",
                table: "Reservations",
                column: "DrivenRouteId",
                principalTable: "DrivenRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
