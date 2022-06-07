using Microsoft.EntityFrameworkCore.Migrations;
using SmartHome.Database.Generators;
using SmartHome.Database.Models;

#nullable disable

namespace SmartHome.Database.Migrations
{
    /// <inheritdoc />
    public partial class addentitytypevalues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateValuesFromEnum<EntityTypeEnum>("EntityType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
