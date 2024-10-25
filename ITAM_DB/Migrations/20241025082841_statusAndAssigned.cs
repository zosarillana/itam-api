using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITAM_DB.Migrations
{
    /// <inheritdoc />
    public partial class statusAndAssigned : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pc_Cards_Itot_Pcs_Itot_Pcid",
                table: "Pc_Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Pc_Cards_Itot_Peripherals_Itot_Peripheralid",
                table: "Pc_Cards");

            migrationBuilder.DropIndex(
                name: "IX_Pc_Cards_Itot_Pcid",
                table: "Pc_Cards");

            migrationBuilder.DropIndex(
                name: "IX_Pc_Cards_Itot_Peripheralid",
                table: "Pc_Cards");

            migrationBuilder.DropColumn(
                name: "Itot_Pcid",
                table: "Pc_Cards");

            migrationBuilder.DropColumn(
                name: "Itot_Peripheralid",
                table: "Pc_Cards");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Itot_Pcid",
                table: "Pc_Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Itot_Peripheralid",
                table: "Pc_Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pc_Cards_Itot_Pcid",
                table: "Pc_Cards",
                column: "Itot_Pcid");

            migrationBuilder.CreateIndex(
                name: "IX_Pc_Cards_Itot_Peripheralid",
                table: "Pc_Cards",
                column: "Itot_Peripheralid");

            migrationBuilder.AddForeignKey(
                name: "FK_Pc_Cards_Itot_Pcs_Itot_Pcid",
                table: "Pc_Cards",
                column: "Itot_Pcid",
                principalTable: "Itot_Pcs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pc_Cards_Itot_Peripherals_Itot_Peripheralid",
                table: "Pc_Cards",
                column: "Itot_Peripheralid",
                principalTable: "Itot_Peripherals",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
