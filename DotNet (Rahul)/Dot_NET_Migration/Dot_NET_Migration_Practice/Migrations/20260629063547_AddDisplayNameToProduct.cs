using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dot_NET_Migration_Practice.Migrations
{
    /// <inheritdoc />
    public partial class AddDisplayNameToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
               name: "DisplayName",
               table: "Products",
               type: "nvarchar(max)",
               nullable: true);

            migrationBuilder.Sql("Update Products set DisplayName=Name+'('+SKU+')'");

            migrationBuilder.AlterColumn<string>(
               name: "DisplayName",
               table: "Products",
               type: "nvarchar(max)",
               nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "DisplayName",
               table: "Products");
        }
    }
}
