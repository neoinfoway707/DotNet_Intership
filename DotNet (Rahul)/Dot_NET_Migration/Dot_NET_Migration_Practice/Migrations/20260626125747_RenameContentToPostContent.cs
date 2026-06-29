using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dot_NET_Migration_Practice.Migrations
{
    /// <inheritdoc />
    public partial class RenameContentToPostContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Posts",
                newName: "PostContent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostContent",
                table: "Posts",
                newName: "Content");
        }
    }
}
