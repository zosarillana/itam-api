using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITAM_DB.Migrations
{
    /// <inheritdoc />
    public partial class PositionForCards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "position",
                table: "User_Cards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "position",
                table: "Pc_Cards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "position",
                table: "User_Cards");

            migrationBuilder.DropColumn(
                name: "position",
                table: "Pc_Cards");
        }
    }
}
