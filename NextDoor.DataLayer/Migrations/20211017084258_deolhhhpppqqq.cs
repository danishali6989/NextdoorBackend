using Microsoft.EntityFrameworkCore.Migrations;

namespace NextDoor.DataLayer.Migrations
{
    public partial class deolhhhpppqqq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Response1",
                table: "Poll");

            migrationBuilder.DropColumn(
                name: "Response2",
                table: "Poll");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Response1",
                table: "Poll",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Response2",
                table: "Poll",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
