using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Infra.Migrations
{
    public partial class DefaultCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ShopCarts",
                columns: new[] { "Id", "CreationDate", "FinishedDate", "OriginalTotalPrice", "TotalDiscount", "TotalPrice" },
                values: new object[] { 1, new DateTime(2022, 6, 21, 5, 29, 12, 38, DateTimeKind.Local).AddTicks(6008), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShopCarts",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
