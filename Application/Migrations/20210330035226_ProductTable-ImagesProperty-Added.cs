using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class ProductTableImagesPropertyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "productId",
                table: "Images",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_productId",
                table: "Images",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Products_productId",
                table: "Images",
                column: "productId",
                principalTable: "Products",
                principalColumn: "productId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Products_productId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_productId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "productId",
                table: "Images");
        }
    }
}
