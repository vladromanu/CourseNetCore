using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotels.Api.Migrations
{
    public partial class RoomsMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Amenities",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Rooms",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MaxAdultOccupancy",
                table: "Rooms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxChildOccupancy",
                table: "Rooms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Rooms",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amenities",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "MaxAdultOccupancy",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "MaxChildOccupancy",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Rooms");
        }
    }
}
