using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class RenamedEntityField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RecipientUSerName",
                table: "Messages",
                newName: "RecipientUserName");

            migrationBuilder.RenameColumn(
                name: "RecipentDeleted",
                table: "Messages",
                newName: "RecipientDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RecipientUserName",
                table: "Messages",
                newName: "RecipientUSerName");

            migrationBuilder.RenameColumn(
                name: "RecipientDeleted",
                table: "Messages",
                newName: "RecipentDeleted");
        }
    }
}
