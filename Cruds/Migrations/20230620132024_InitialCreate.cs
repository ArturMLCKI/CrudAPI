using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cruds.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProduktyId",
                table: "cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_cars_ProduktyId",
                table: "cars",
                column: "ProduktyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_cars_Produktys_ProduktyId",
                table: "cars",
                column: "ProduktyId",
                principalTable: "Produktys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cars_Produktys_ProduktyId",
                table: "cars");

            migrationBuilder.DropIndex(
                name: "IX_cars_ProduktyId",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "ProduktyId",
                table: "cars");
        }
    }
}
