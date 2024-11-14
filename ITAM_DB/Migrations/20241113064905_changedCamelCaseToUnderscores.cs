using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITAM_DB.Migrations
{
    /// <inheritdoc />
    public partial class changedCamelCaseToUnderscores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Users",
                newName: "middle_name");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Users",
                newName: "last_name");

            migrationBuilder.AddColumn<string>(
                name: "first_name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "first_name",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "middle_name",
                table: "Users",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Users",
                newName: "firstName");
        }
    }
}
