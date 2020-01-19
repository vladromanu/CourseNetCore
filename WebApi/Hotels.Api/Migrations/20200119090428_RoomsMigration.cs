using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotels.Api.Migrations
{
    public partial class RoomsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "number",
                table: "Rooms",
                newName: "Number");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Rooms",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Rooms",
                newName: "number");

            migrationBuilder.AlterColumn<string>(
                name: "number",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
