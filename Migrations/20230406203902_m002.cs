using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam2.Migrations
{
    /// <inheritdoc />
    public partial class m002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppID",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comments",
                newName: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Comments",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "AppID",
                table: "Comments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
