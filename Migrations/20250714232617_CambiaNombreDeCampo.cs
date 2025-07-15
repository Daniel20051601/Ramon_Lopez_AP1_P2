using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ramon_Lopez_AP1_P2.Migrations
{
    /// <inheritdoc />
    public partial class CambiaNombreDeCampo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VentaDetalleId",
                table: "EntradasDetalle",
                newName: "EntradasDetalleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EntradasDetalleId",
                table: "EntradasDetalle",
                newName: "VentaDetalleId");
        }
    }
}
