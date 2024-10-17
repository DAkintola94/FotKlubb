using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FotKlubb.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation_Three : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserActivity_LoginProfile_LoginId1",
                table: "UserActivity");

            migrationBuilder.DropIndex(
                name: "IX_UserActivity_LoginId1",
                table: "UserActivity");

            migrationBuilder.RenameColumn(
                name: "LoginId1",
                table: "UserActivity",
                newName: "LoginId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LoginId",
                table: "UserActivity",
                newName: "LoginId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserActivity_LoginId1",
                table: "UserActivity",
                column: "LoginId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserActivity_LoginProfile_LoginId1",
                table: "UserActivity",
                column: "LoginId1",
                principalTable: "LoginProfile",
                principalColumn: "LoginId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
