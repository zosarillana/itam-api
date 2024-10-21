using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITAM_DB.Migrations
{
    /// <inheritdoc />
    public partial class RefactoredFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "accountable_user",
                table: "Itot_Peripherals");

            migrationBuilder.DropColumn(
                name: "accountable_user",
                table: "Itot_Pcs");

            migrationBuilder.DropColumn(
                name: "bu",
                table: "Itot_Pcs");

            migrationBuilder.DropColumn(
                name: "department",
                table: "Itot_Pcs");

            migrationBuilder.RenameColumn(
                name: "location",
                table: "Itot_Peripherals",
                newName: "size");

            migrationBuilder.RenameColumn(
                name: "inventory_tag",
                table: "Itot_Peripherals",
                newName: "peripheral_type");

            migrationBuilder.RenameColumn(
                name: "department",
                table: "Itot_Peripherals",
                newName: "li_description");

            migrationBuilder.RenameColumn(
                name: "bu",
                table: "Itot_Peripherals",
                newName: "asset_barcode");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Itot_Pcs",
                newName: "pc_type");

            migrationBuilder.RenameColumn(
                name: "location",
                table: "Itot_Pcs",
                newName: "li_description");

            migrationBuilder.RenameColumn(
                name: "inventory_tag",
                table: "Itot_Pcs",
                newName: "asset_barcode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "size",
                table: "Itot_Peripherals",
                newName: "location");

            migrationBuilder.RenameColumn(
                name: "peripheral_type",
                table: "Itot_Peripherals",
                newName: "inventory_tag");

            migrationBuilder.RenameColumn(
                name: "li_description",
                table: "Itot_Peripherals",
                newName: "department");

            migrationBuilder.RenameColumn(
                name: "asset_barcode",
                table: "Itot_Peripherals",
                newName: "bu");

            migrationBuilder.RenameColumn(
                name: "pc_type",
                table: "Itot_Pcs",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "li_description",
                table: "Itot_Pcs",
                newName: "location");

            migrationBuilder.RenameColumn(
                name: "asset_barcode",
                table: "Itot_Pcs",
                newName: "inventory_tag");

            migrationBuilder.AddColumn<string>(
                name: "accountable_user",
                table: "Itot_Peripherals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "accountable_user",
                table: "Itot_Pcs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "bu",
                table: "Itot_Pcs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "department",
                table: "Itot_Pcs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
