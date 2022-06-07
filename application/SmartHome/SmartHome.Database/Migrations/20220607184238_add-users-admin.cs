using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHome.Database.Migrations
{
    /// <inheritdoc />
    public partial class addusersadmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO Users
                (Id, UserName, Password, 'Group', CreatedOn, CreatedBy, UpdatedOn, UpdatedBy)
                VALUES('ec79924a-c151-4b56-b3ab-2288255b2eac', 'admin', 'admin', 1, DateTime(), 'admin', DateTime(), 'admin'); 
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DELETE FROM Users
                WHERE Id='ec79924a-c151-4b56-b3ab-2288255b2eac';
            ");
        }
    }
}
