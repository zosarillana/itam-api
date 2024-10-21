using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITAM_DB.Migrations
{
    /// <inheritdoc />
    public partial class RefactoredFieldsItot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "type",
                table: "Itot_Peripherals");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "Itot_Peripherals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
