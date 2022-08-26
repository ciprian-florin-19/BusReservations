using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusReservations.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class many : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusDrivenRoute",
                columns: table => new
                {
                    BusesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DrivenRoutesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusDrivenRoute", x => new { x.BusesId, x.DrivenRoutesId });
                    table.ForeignKey(
                        name: "FK_BusDrivenRoute_Buses_BusesId",
                        column: x => x.BusesId,
                        principalTable: "Buses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusDrivenRoute_DrivenRoutes_DrivenRoutesId",
                        column: x => x.DrivenRoutesId,
                        principalTable: "DrivenRoutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusDrivenRoute_DrivenRoutesId",
                table: "BusDrivenRoute",
                column: "DrivenRoutesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusDrivenRoute");
        }
    }
}
