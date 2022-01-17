using Microsoft.EntityFrameworkCore.Migrations;

namespace NextDoor.DataLayer.Migrations
{
    public partial class eventtimestamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventTimestamp",
                table: "Event",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventTimestamp",
                table: "Event");
        }
    }
}
