using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inmobiliaria.Migrations
{
    public partial class RentalCasa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RentalCasa",
                columns: table => new
                {
                    RentalCasaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaAlquiler = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    CasaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalCasa", x => x.RentalCasaId);
                    table.ForeignKey(
                        name: "FK_RentalCasa_Casa_CasaID",
                        column: x => x.CasaID,
                        principalTable: "Casa",
                        principalColumn: "casaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentalCasa_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "clienteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentalDetailTemp",
                columns: table => new
                {
                    RentalDetailTempID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    casaID = table.Column<int>(type: "int", nullable: false),
                    nombreCasa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalDetailTemp", x => x.RentalDetailTempID);
                });

            migrationBuilder.CreateTable(
                name: "RentalDetail",
                columns: table => new
                {
                    RentalDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentalCasaId = table.Column<int>(type: "int", nullable: false),
                    casaID = table.Column<int>(type: "int", nullable: false),
                    nombreCasa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalDetail", x => x.RentalDetailID);
                    table.ForeignKey(
                        name: "FK_RentalDetail_Casa_casaID",
                        column: x => x.casaID,
                        principalTable: "Casa",
                        principalColumn: "casaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentalDetail_RentalCasa_RentalCasaId",
                        column: x => x.RentalCasaId,
                        principalTable: "RentalCasa",
                        principalColumn: "RentalCasaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentalCasa_CasaID",
                table: "RentalCasa",
                column: "CasaID");

            migrationBuilder.CreateIndex(
                name: "IX_RentalCasa_ClienteId",
                table: "RentalCasa",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalDetail_casaID",
                table: "RentalDetail",
                column: "casaID");

            migrationBuilder.CreateIndex(
                name: "IX_RentalDetail_RentalCasaId",
                table: "RentalDetail",
                column: "RentalCasaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentalDetail");

            migrationBuilder.DropTable(
                name: "RentalDetailTemp");

            migrationBuilder.DropTable(
                name: "RentalCasa");
        }
    }
}
