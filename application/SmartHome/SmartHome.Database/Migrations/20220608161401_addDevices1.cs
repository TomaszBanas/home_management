using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHome.Database.Migrations
{
    /// <inheritdoc />
    public partial class addDevices1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "Devices",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Devices");
        }
    }
}
