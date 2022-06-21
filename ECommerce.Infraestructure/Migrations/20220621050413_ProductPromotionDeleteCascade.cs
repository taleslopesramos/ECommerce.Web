using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Infra.Migrations
{
    public partial class ProductPromotionDeleteCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ProductPromotionFK",
                table: "Promotions");

            migrationBuilder.AddForeignKey(
                name: "ProductPromotionFK",
                table: "Promotions",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ProductPromotionFK",
                table: "Promotions");

            migrationBuilder.AddForeignKey(
                name: "ProductPromotionFK",
                table: "Promotions",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
