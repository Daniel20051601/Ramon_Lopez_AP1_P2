using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ramon_Lopez_AP1_P2.Migrations
{
    /// <inheritdoc />
    public partial class AgregaDatosDeProductos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Descripcion", "EsCompuesto", "Existencia", "Peso" },
                values: new object[,]
                {
                    { 1, "Maní", false, 100.0m, 5.00m },
                    { 2, "Almendra", false, 75.0m, 10.00m },
                    { 3, "Pistacho", false, 50.0m, 20.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 3);
        }
    }
}
