using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dot_NET_Migration_Practice.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTechnologyCategoryName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Tech & Innovation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Technology");
        }
    }
}
