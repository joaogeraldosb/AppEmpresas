using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Empresas.Migrations
{
    public partial class EightthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UltimoLogin",
                schema: "dbo",
                table: "Users",
                newName: "LastLoginDate");

            migrationBuilder.RenameColumn(
                name: "Senha",
                schema: "dbo",
                table: "Users",
                newName: "Password");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Users",
                columns: new[] { "Id", "Active", "LastLoginDate", "Name", "Password" },
                values: new object[] { 1, true, null, "testeapple@ioasys.com.br", new byte[] { 215, 109, 248, 215, 109, 248 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "Password",
                schema: "dbo",
                table: "Users",
                newName: "Senha");

            migrationBuilder.RenameColumn(
                name: "LastLoginDate",
                schema: "dbo",
                table: "Users",
                newName: "UltimoLogin");
        }
    }
}
