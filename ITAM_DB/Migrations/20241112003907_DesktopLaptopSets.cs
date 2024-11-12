using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITAM_DB.Migrations
{
    /// <inheritdoc />
    public partial class DesktopLaptopSets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "srlNumber",
                table: "WebCams",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "assetCode",
                table: "WebCams",
                newName: "serial_no");

            migrationBuilder.RenameColumn(
                name: "acqDate",
                table: "WebCams",
                newName: "li_description");

            migrationBuilder.RenameColumn(
                name: "srlNumber",
                table: "UPSs",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "assetCode",
                table: "UPSs",
                newName: "serial_no");

            migrationBuilder.RenameColumn(
                name: "acqDate",
                table: "UPSs",
                newName: "li_description");

            migrationBuilder.RenameColumn(
                name: "srlNumber",
                table: "Mouses",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "assetCode",
                table: "Mouses",
                newName: "serial_no");

            migrationBuilder.RenameColumn(
                name: "acqDate",
                table: "Mouses",
                newName: "li_description");

            migrationBuilder.RenameColumn(
                name: "srlNumber",
                table: "Monitors",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "assetCode",
                table: "Monitors",
                newName: "serial_no");

            migrationBuilder.RenameColumn(
                name: "acqDate",
                table: "Monitors",
                newName: "li_description");

            migrationBuilder.RenameColumn(
                name: "srlNumber",
                table: "LanAdapters",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "assetCode",
                table: "LanAdapters",
                newName: "serial_no");

            migrationBuilder.RenameColumn(
                name: "acqDate",
                table: "LanAdapters",
                newName: "li_description");

            migrationBuilder.RenameColumn(
                name: "srlNumber",
                table: "Keyboards",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "assetCode",
                table: "Keyboards",
                newName: "serial_no");

            migrationBuilder.RenameColumn(
                name: "acqDate",
                table: "Keyboards",
                newName: "li_description");

            migrationBuilder.RenameColumn(
                name: "srlNumber",
                table: "ExternalDrives",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "assetCode",
                table: "ExternalDrives",
                newName: "serial_no");

            migrationBuilder.RenameColumn(
                name: "acqDate",
                table: "ExternalDrives",
                newName: "li_description");

            migrationBuilder.RenameColumn(
                name: "srlNumber",
                table: "Dongles",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "assetCode",
                table: "Dongles",
                newName: "serial_no");

            migrationBuilder.RenameColumn(
                name: "acqDate",
                table: "Dongles",
                newName: "li_description");

            migrationBuilder.RenameColumn(
                name: "srlNumber",
                table: "Bags",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "assetCode",
                table: "Bags",
                newName: "serial_no");

            migrationBuilder.RenameColumn(
                name: "acqDate",
                table: "Bags",
                newName: "li_description");

            migrationBuilder.RenameColumn(
                name: "srlNumber",
                table: "AVRs",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "assetCode",
                table: "AVRs",
                newName: "serial_no");

            migrationBuilder.RenameColumn(
                name: "acqDate",
                table: "AVRs",
                newName: "li_description");

            migrationBuilder.AddColumn<string>(
                name: "acquired_date",
                table: "WebCams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "asset_barcode",
                table: "WebCams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "assigned",
                table: "WebCams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "acquired_date",
                table: "UPSs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "asset_barcode",
                table: "UPSs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "assigned",
                table: "UPSs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "acquired_date",
                table: "Mouses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "asset_barcode",
                table: "Mouses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "assigned",
                table: "Mouses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "acquired_date",
                table: "Monitors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "asset_barcode",
                table: "Monitors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "assigned",
                table: "Monitors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "acquired_date",
                table: "LanAdapters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "asset_barcode",
                table: "LanAdapters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "assigned",
                table: "LanAdapters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "acquired_date",
                table: "Keyboards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "asset_barcode",
                table: "Keyboards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "assigned",
                table: "Keyboards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "acquired_date",
                table: "ExternalDrives",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "asset_barcode",
                table: "ExternalDrives",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "assigned",
                table: "ExternalDrives",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "acquired_date",
                table: "Dongles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "asset_barcode",
                table: "Dongles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "assigned",
                table: "Dongles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "acquired_date",
                table: "Bags",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "asset_barcode",
                table: "Bags",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "assigned",
                table: "Bags",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "acquired_date",
                table: "AVRs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "asset_barcode",
                table: "AVRs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "assigned",
                table: "AVRs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Desktops",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    processor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    storage_capacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    storage_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    operating_system = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    graphics = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    assigned = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    li_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    acquired_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    asset_barcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    serial_no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desktops", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DesktopSets",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    desktop_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    avr_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dongle_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    keyboard_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lanAdapter_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    monitor_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mouse_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ups_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    webcam_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    assigned = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    li_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    acquired_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesktopSets", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Laptops",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    processor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    storage_capacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    storage_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    operating_system = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    graphics = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    assigned = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    li_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    acquired_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    asset_barcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    serial_no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptops", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "LaptopSets",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    desktop_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dongle_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    keyboard_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lanAdapter_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    monitor_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mouse_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    webcam_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bag_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    externalDrive_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    assigned = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    li_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    acquired_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaptopSets", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Desktops");

            migrationBuilder.DropTable(
                name: "DesktopSets");

            migrationBuilder.DropTable(
                name: "Laptops");

            migrationBuilder.DropTable(
                name: "LaptopSets");

            migrationBuilder.DropColumn(
                name: "acquired_date",
                table: "WebCams");

            migrationBuilder.DropColumn(
                name: "asset_barcode",
                table: "WebCams");

            migrationBuilder.DropColumn(
                name: "assigned",
                table: "WebCams");

            migrationBuilder.DropColumn(
                name: "acquired_date",
                table: "UPSs");

            migrationBuilder.DropColumn(
                name: "asset_barcode",
                table: "UPSs");

            migrationBuilder.DropColumn(
                name: "assigned",
                table: "UPSs");

            migrationBuilder.DropColumn(
                name: "acquired_date",
                table: "Mouses");

            migrationBuilder.DropColumn(
                name: "asset_barcode",
                table: "Mouses");

            migrationBuilder.DropColumn(
                name: "assigned",
                table: "Mouses");

            migrationBuilder.DropColumn(
                name: "acquired_date",
                table: "Monitors");

            migrationBuilder.DropColumn(
                name: "asset_barcode",
                table: "Monitors");

            migrationBuilder.DropColumn(
                name: "assigned",
                table: "Monitors");

            migrationBuilder.DropColumn(
                name: "acquired_date",
                table: "LanAdapters");

            migrationBuilder.DropColumn(
                name: "asset_barcode",
                table: "LanAdapters");

            migrationBuilder.DropColumn(
                name: "assigned",
                table: "LanAdapters");

            migrationBuilder.DropColumn(
                name: "acquired_date",
                table: "Keyboards");

            migrationBuilder.DropColumn(
                name: "asset_barcode",
                table: "Keyboards");

            migrationBuilder.DropColumn(
                name: "assigned",
                table: "Keyboards");

            migrationBuilder.DropColumn(
                name: "acquired_date",
                table: "ExternalDrives");

            migrationBuilder.DropColumn(
                name: "asset_barcode",
                table: "ExternalDrives");

            migrationBuilder.DropColumn(
                name: "assigned",
                table: "ExternalDrives");

            migrationBuilder.DropColumn(
                name: "acquired_date",
                table: "Dongles");

            migrationBuilder.DropColumn(
                name: "asset_barcode",
                table: "Dongles");

            migrationBuilder.DropColumn(
                name: "assigned",
                table: "Dongles");

            migrationBuilder.DropColumn(
                name: "acquired_date",
                table: "Bags");

            migrationBuilder.DropColumn(
                name: "asset_barcode",
                table: "Bags");

            migrationBuilder.DropColumn(
                name: "assigned",
                table: "Bags");

            migrationBuilder.DropColumn(
                name: "acquired_date",
                table: "AVRs");

            migrationBuilder.DropColumn(
                name: "asset_barcode",
                table: "AVRs");

            migrationBuilder.DropColumn(
                name: "assigned",
                table: "AVRs");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "WebCams",
                newName: "srlNumber");

            migrationBuilder.RenameColumn(
                name: "serial_no",
                table: "WebCams",
                newName: "assetCode");

            migrationBuilder.RenameColumn(
                name: "li_description",
                table: "WebCams",
                newName: "acqDate");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "UPSs",
                newName: "srlNumber");

            migrationBuilder.RenameColumn(
                name: "serial_no",
                table: "UPSs",
                newName: "assetCode");

            migrationBuilder.RenameColumn(
                name: "li_description",
                table: "UPSs",
                newName: "acqDate");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Mouses",
                newName: "srlNumber");

            migrationBuilder.RenameColumn(
                name: "serial_no",
                table: "Mouses",
                newName: "assetCode");

            migrationBuilder.RenameColumn(
                name: "li_description",
                table: "Mouses",
                newName: "acqDate");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Monitors",
                newName: "srlNumber");

            migrationBuilder.RenameColumn(
                name: "serial_no",
                table: "Monitors",
                newName: "assetCode");

            migrationBuilder.RenameColumn(
                name: "li_description",
                table: "Monitors",
                newName: "acqDate");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "LanAdapters",
                newName: "srlNumber");

            migrationBuilder.RenameColumn(
                name: "serial_no",
                table: "LanAdapters",
                newName: "assetCode");

            migrationBuilder.RenameColumn(
                name: "li_description",
                table: "LanAdapters",
                newName: "acqDate");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Keyboards",
                newName: "srlNumber");

            migrationBuilder.RenameColumn(
                name: "serial_no",
                table: "Keyboards",
                newName: "assetCode");

            migrationBuilder.RenameColumn(
                name: "li_description",
                table: "Keyboards",
                newName: "acqDate");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "ExternalDrives",
                newName: "srlNumber");

            migrationBuilder.RenameColumn(
                name: "serial_no",
                table: "ExternalDrives",
                newName: "assetCode");

            migrationBuilder.RenameColumn(
                name: "li_description",
                table: "ExternalDrives",
                newName: "acqDate");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Dongles",
                newName: "srlNumber");

            migrationBuilder.RenameColumn(
                name: "serial_no",
                table: "Dongles",
                newName: "assetCode");

            migrationBuilder.RenameColumn(
                name: "li_description",
                table: "Dongles",
                newName: "acqDate");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Bags",
                newName: "srlNumber");

            migrationBuilder.RenameColumn(
                name: "serial_no",
                table: "Bags",
                newName: "assetCode");

            migrationBuilder.RenameColumn(
                name: "li_description",
                table: "Bags",
                newName: "acqDate");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "AVRs",
                newName: "srlNumber");

            migrationBuilder.RenameColumn(
                name: "serial_no",
                table: "AVRs",
                newName: "assetCode");

            migrationBuilder.RenameColumn(
                name: "li_description",
                table: "AVRs",
                newName: "acqDate");
        }
    }
}
