using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FotKlubb.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation_Five : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsersActivityId",
                table: "UserActivity",
                newName: "ActivityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ActivityId",
                table: "UserActivity",
                newName: "UsersActivityId");
        }
    }
}
