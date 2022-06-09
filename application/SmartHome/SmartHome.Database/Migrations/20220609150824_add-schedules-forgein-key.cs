using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHome.Database.Migrations
{
    /// <inheritdoc />
    public partial class addschedulesforgeinkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DeviceId",
                table: "Schedules",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_DeviceId",
                table: "Schedules",
                column: "DeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Devices_DeviceId",
                table: "Schedules",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Devices_DeviceId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_DeviceId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "Schedules");
        }
    }
}
