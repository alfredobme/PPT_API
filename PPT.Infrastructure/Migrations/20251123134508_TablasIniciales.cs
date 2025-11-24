using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PPT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TablasIniciales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jugadores",
                columns: table => new
                {
                    JugadorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugadores", x => x.JugadorId);
                });

            migrationBuilder.CreateTable(
                name: "Batallas",
                columns: table => new
                {
                    BatallaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jugador1Id = table.Column<int>(type: "int", nullable: false),
                    Jugador2Id = table.Column<int>(type: "int", nullable: false),
                    GanadorId = table.Column<int>(type: "int", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batallas", x => x.BatallaId);
                    table.ForeignKey(
                        name: "FK_Batallas_Jugadores_GanadorId",
                        column: x => x.GanadorId,
                        principalTable: "Jugadores",
                        principalColumn: "JugadorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Batallas_Jugadores_Jugador1Id",
                        column: x => x.Jugador1Id,
                        principalTable: "Jugadores",
                        principalColumn: "JugadorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Batallas_Jugadores_Jugador2Id",
                        column: x => x.Jugador2Id,
                        principalTable: "Jugadores",
                        principalColumn: "JugadorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Batallas_GanadorId",
                table: "Batallas",
                column: "GanadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Batallas_Jugador1Id",
                table: "Batallas",
                column: "Jugador1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Batallas_Jugador2Id",
                table: "Batallas",
                column: "Jugador2Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Batallas");

            migrationBuilder.DropTable(
                name: "Jugadores");
        }
    }
}
