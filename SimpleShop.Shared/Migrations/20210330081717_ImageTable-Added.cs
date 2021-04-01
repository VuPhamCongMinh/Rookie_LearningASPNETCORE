using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleShop.Shared.Migrations
{
    public partial class ImageTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Products_productId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_productId",
                table: "Images");

            migrationBuilder.AlterColumn<string>(
                name: "productName",
                table: "Products",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "productDescription",
                table: "Products",
                type: "VARCHAR(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(250)",
                oldMaxLength: 250,
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "productName",
                table: "Products",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "productDescription",
                table: "Products",
                type: "VARCHAR(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(250)",
                oldMaxLength: 250);

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
                onDelete: ReferentialAction.Restrict);
        }
    }
}
