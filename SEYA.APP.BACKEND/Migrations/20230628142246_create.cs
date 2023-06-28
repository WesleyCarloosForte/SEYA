using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEYA.APP.BACKEND.Migrations
{
    /// <inheritdoc />
    public partial class create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FinVigencia",
                table: "Pagos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "InicioVigencia",
                table: "Pagos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Timbrado",
                table: "Pagos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Comprobantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumeroActual = table.Column<int>(type: "int", nullable: false),
                    NumeroFinal = table.Column<int>(type: "int", nullable: false),
                    InicioVigencia = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FinVigencia = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PuntoExpedicion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Timbrado = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sucursal = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comprobantes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Comprobantes",
                columns: new[] { "Id", "Descripcion", "FinVigencia", "InicioVigencia", "NumeroActual", "NumeroFinal", "PuntoExpedicion", "Sucursal", "Timbrado" },
                values: new object[] { 1, "Facutra", new DateTime(2023, 12, 28, 11, 22, 46, 228, DateTimeKind.Local).AddTicks(2951), new DateTime(2023, 6, 28, 11, 22, 46, 228, DateTimeKind.Local).AddTicks(2967), 201, 600, "001", "001", "2343242" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comprobantes");

            migrationBuilder.DropColumn(
                name: "FinVigencia",
                table: "Pagos");

            migrationBuilder.DropColumn(
                name: "InicioVigencia",
                table: "Pagos");

            migrationBuilder.DropColumn(
                name: "Timbrado",
                table: "Pagos");
        }
    }
}
