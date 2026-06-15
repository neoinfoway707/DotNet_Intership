using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day_19_Working_with_EF_Core_in_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SmartContainers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TelemetryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentTemperature = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    HumidityPercentage = table.Column<int>(type: "int", nullable: false),
                    DestinationPort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmartContainers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SmartContainers");
        }
    }
}
