using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITAM_DB.Migrations
{
    /// <inheritdoc />
    public partial class WebCamsTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WebCamControllers",
                table: "WebCamControllers");

            migrationBuilder.RenameTable(
                name: "WebCamControllers",
                newName: "WebCams");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WebCams",
                table: "WebCams",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WebCams",
                table: "WebCams");

            migrationBuilder.RenameTable(
                name: "WebCams",
                newName: "WebCamControllers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WebCamControllers",
                table: "WebCamControllers",
                column: "id");
        }
    }
}
