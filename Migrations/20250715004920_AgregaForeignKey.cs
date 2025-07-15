using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ramon_Lopez_AP1_P2.Migrations
{
    /// <inheritdoc />
    public partial class AgregaForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 1,
                column: "Peso",
                value: 10.00m);

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 2,
                column: "Peso",
                value: 5.00m);

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 3,
                column: "Peso",
                value: 20.00m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 1,
                column: "Peso",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 2,
                column: "Peso",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 3,
                column: "Peso",
                value: 0m);
        }
    }
}
