﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleShop.Shared.Migrations
{
    public partial class VariationTable_Removed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Variations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Variations",
                columns: table => new
                {
                    variationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imageId = table.Column<int>(type: "int", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false),
                    variationName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variations", x => x.variationId);
                    table.ForeignKey(
                        name: "FK_Variations_Images_imageId",
                        column: x => x.imageId,
                        principalTable: "Images",
                        principalColumn: "imageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Variations_imageId",
                table: "Variations",
                column: "imageId");
        }
    }
}
