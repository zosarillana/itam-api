using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITAM_DB.Migrations
{
    /// <inheritdoc />
    public partial class AddedHistoryColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "history",
                table: "Itot_Peripherals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "history",
                table: "Itot_Pcs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "history",
                table: "Itot_Peripherals");

            migrationBuilder.DropColumn(
                name: "history",
                table: "Itot_Pcs");
        }
    }
}
