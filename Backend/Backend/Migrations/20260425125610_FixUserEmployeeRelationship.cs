using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class FixUserEmployeeRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_UsersID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UsersID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UsersID",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsersID",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UsersID",
                table: "Users",
                column: "UsersID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_UsersID",
                table: "Users",

                column: "UsersID",
                principalTable: "Users",
                principalColumn: "ID");
        }
    }
}
