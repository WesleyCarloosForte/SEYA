using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEYA.APP.BACKEND.Migrations
{
    /// <inheritdoc />
    public partial class clienteDeuda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pendiente",
                table: "Deudas");

            migrationBuilder.CreateIndex(
                name: "IX_Deudas_ClienteId",
                table: "Deudas",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deudas_Clientes_ClienteId",
                table: "Deudas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deudas_Clientes_ClienteId",
                table: "Deudas");

            migrationBuilder.DropIndex(
                name: "IX_Deudas_ClienteId",
                table: "Deudas");

            migrationBuilder.AddColumn<bool>(
                name: "Pendiente",
                table: "Deudas",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
