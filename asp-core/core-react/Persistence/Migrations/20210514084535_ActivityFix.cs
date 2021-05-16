using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class ActivityFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sity",
                table: "Activities",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Desctiption",
                table: "Activities",
                newName: "City");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Activities",
                newName: "Sity");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Activities",
                newName: "Desctiption");
        }
    }
}
