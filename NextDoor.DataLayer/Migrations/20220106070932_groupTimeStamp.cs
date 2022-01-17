using Microsoft.EntityFrameworkCore.Migrations;

namespace NextDoor.DataLayer.Migrations
{
    public partial class groupTimeStamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GroupTimeStamp",
                table: "Group",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupTimeStamp",
                table: "Group");
        }
    }
}
