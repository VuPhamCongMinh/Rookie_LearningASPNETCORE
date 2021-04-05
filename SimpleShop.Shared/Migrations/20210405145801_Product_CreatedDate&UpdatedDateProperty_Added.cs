using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleShop.Shared.Migrations
{
    public partial class Product_CreatedDateUpdatedDateProperty_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "uploadDate",
                table: "Products",
                newName: "updatedDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "createdDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createdDate",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "updatedDate",
                table: "Products",
                newName: "uploadDate");
        }
    }
}
