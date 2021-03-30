using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class ProductTableImageColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "productId",
                table: "Images");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "productId",
                table: "Images",
                type: "int",
                nullable: true);
        }
    }
}
