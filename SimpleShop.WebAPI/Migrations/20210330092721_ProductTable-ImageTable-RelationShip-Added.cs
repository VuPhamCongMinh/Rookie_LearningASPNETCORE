using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleShop.WebAPI.Migrations
{
    public partial class ProductTableImageTableRelationShipAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Images_imageId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_imageId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "imageId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "productId",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddColumn<int>(
                name: "imageId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_imageId",
                table: "Products",
                column: "imageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Images_imageId",
                table: "Products",
                column: "imageId",
                principalTable: "Images",
                principalColumn: "imageId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
