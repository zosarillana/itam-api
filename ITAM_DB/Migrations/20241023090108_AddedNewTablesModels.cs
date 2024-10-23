using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITAM_DB.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewTablesModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pc_Cards",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emp_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contact_no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dept_no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    company_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_assigned = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pc_id = table.Column<int>(type: "int", nullable: false),
                    peripheral_id = table.Column<int>(type: "int", nullable: false),
                    date_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pc_Cards", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User_Cards",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emp_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contact_no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dept_no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    company_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_assigned = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pc_id = table.Column<int>(type: "int", nullable: false),
                    peripheral_id = table.Column<int>(type: "int", nullable: false),
                    date_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Cards", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pc_Cards");

            migrationBuilder.DropTable(
                name: "User_Cards");
        }
    }
}
