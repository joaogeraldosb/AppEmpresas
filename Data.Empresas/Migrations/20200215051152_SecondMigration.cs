using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Empresas.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Enterprise_Name",
                schema: "dbo",
                table: "Enterprises",
                newName: "ContactName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactName",
                schema: "dbo",
                table: "Enterprises",
                newName: "Enterprise_Name");
        }
    }
}
