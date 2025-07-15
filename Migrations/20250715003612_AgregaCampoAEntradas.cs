using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ramon_Lopez_AP1_P2.Migrations
{
    /// <inheritdoc />
    public partial class AgregaCampoAEntradas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PesoTotal",
                table: "EntradasDetalle");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Productos",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Concepto",
                table: "Entradas",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "CantidadProducida",
                table: "Entradas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdProducido",
                table: "Entradas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PesoTotal",
                table: "Entradas",
                type: "numeric(10,2)",
                nullable: false,
                defaultValue: 0m);

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
                columns: new[] { "Descripcion", "Existencia", "Peso" },
                values: new object[] { "Pistachos", 100m, 0m });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 3,
                columns: new[] { "Descripcion", "Existencia", "Peso" },
                values: new object[] { "Almendras", 100m, 0m });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Descripcion", "EsCompuesto", "Existencia", "Peso" },
                values: new object[,]
                {
                    { 4, "Frutos Mixtos 200gr", true, 0m, 200.00m },
                    { 5, "Frutos Mixtos 400gr", true, 0m, 400.00m },
                    { 6, "Frutos Mixtos 600gr", true, 0m, 600.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_IdProducido",
                table: "Entradas",
                column: "IdProducido");

            migrationBuilder.AddForeignKey(
                name: "FK_Entradas_Productos_IdProducido",
                table: "Entradas",
                column: "IdProducido",
                principalTable: "Productos",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entradas_Productos_IdProducido",
                table: "Entradas");

            migrationBuilder.DropIndex(
                name: "IX_Entradas_IdProducido",
                table: "Entradas");

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "CantidadProducida",
                table: "Entradas");

            migrationBuilder.DropColumn(
                name: "IdProducido",
                table: "Entradas");

            migrationBuilder.DropColumn(
                name: "PesoTotal",
                table: "Entradas");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Productos",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<decimal>(
                name: "PesoTotal",
                table: "EntradasDetalle",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Concepto",
                table: "Entradas",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 1,
                column: "Peso",
                value: 5.00m);

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 2,
                columns: new[] { "Descripcion", "Existencia", "Peso" },
                values: new object[] { "Almendra", 75.0m, 10.00m });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 3,
                columns: new[] { "Descripcion", "Existencia", "Peso" },
                values: new object[] { "Pistacho", 50.0m, 20.00m });
        }
    }
}
