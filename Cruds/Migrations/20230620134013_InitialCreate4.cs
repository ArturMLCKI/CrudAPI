using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cruds.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cars_Produktys_ProduktyId",
                table: "cars");

            migrationBuilder.DropIndex(
                name: "IX_cars_ProduktyId",
                table: "cars");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_cars_ProduktyId",
                table: "cars",
                column: "ProduktyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produktys_cars_Id",
                table: "Produktys",
                column: "Id",
                principalTable: "cars",
                principalColumn: "ProduktyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produktys_cars_Id",
                table: "Produktys");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_cars_ProduktyId",
                table: "cars");

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
    }
}
