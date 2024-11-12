using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITAM_DB.Migrations
{
    /// <inheritdoc />
    public partial class addedHisories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "assigned",
                table: "DesktopSets",
                newName: "user_id");

            migrationBuilder.AddColumn<string>(
                name: "set_history",
                table: "WebCams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "user_history",
                table: "WebCams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "set_history",
                table: "UPSs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "user_history",
                table: "UPSs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "set_history",
                table: "Mouses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "user_history",
                table: "Mouses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "set_history",
                table: "Monitors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "user_history",
                table: "Monitors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "user_id",
                table: "LaptopSets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "user_history",
                table: "Laptops",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "set_history",
                table: "LanAdapters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "user_history",
                table: "LanAdapters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "set_history",
                table: "Keyboards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "user_history",
                table: "Keyboards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "set_history",
                table: "ExternalDrives",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "user_history",
                table: "ExternalDrives",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "set_history",
                table: "Dongles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "user_history",
                table: "Dongles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "user_history",
                table: "Desktops",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "set_history",
                table: "Bags",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "user_history",
                table: "Bags",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "set_history",
                table: "AVRs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "user_history",
                table: "AVRs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "set_history",
                table: "WebCams");

            migrationBuilder.DropColumn(
                name: "user_history",
                table: "WebCams");

            migrationBuilder.DropColumn(
                name: "set_history",
                table: "UPSs");

            migrationBuilder.DropColumn(
                name: "user_history",
                table: "UPSs");

            migrationBuilder.DropColumn(
                name: "set_history",
                table: "Mouses");

            migrationBuilder.DropColumn(
                name: "user_history",
                table: "Mouses");

            migrationBuilder.DropColumn(
                name: "set_history",
                table: "Monitors");

            migrationBuilder.DropColumn(
                name: "user_history",
                table: "Monitors");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "LaptopSets");

            migrationBuilder.DropColumn(
                name: "user_history",
                table: "Laptops");

            migrationBuilder.DropColumn(
                name: "set_history",
                table: "LanAdapters");

            migrationBuilder.DropColumn(
                name: "user_history",
                table: "LanAdapters");

            migrationBuilder.DropColumn(
                name: "set_history",
                table: "Keyboards");

            migrationBuilder.DropColumn(
                name: "user_history",
                table: "Keyboards");

            migrationBuilder.DropColumn(
                name: "set_history",
                table: "ExternalDrives");

            migrationBuilder.DropColumn(
                name: "user_history",
                table: "ExternalDrives");

            migrationBuilder.DropColumn(
                name: "set_history",
                table: "Dongles");

            migrationBuilder.DropColumn(
                name: "user_history",
                table: "Dongles");

            migrationBuilder.DropColumn(
                name: "user_history",
                table: "Desktops");

            migrationBuilder.DropColumn(
                name: "set_history",
                table: "Bags");

            migrationBuilder.DropColumn(
                name: "user_history",
                table: "Bags");

            migrationBuilder.DropColumn(
                name: "set_history",
                table: "AVRs");

            migrationBuilder.DropColumn(
                name: "user_history",
                table: "AVRs");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "DesktopSets",
                newName: "assigned");
        }
    }
}
