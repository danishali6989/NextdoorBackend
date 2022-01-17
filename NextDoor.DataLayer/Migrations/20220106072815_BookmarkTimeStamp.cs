using Microsoft.EntityFrameworkCore.Migrations;

namespace NextDoor.DataLayer.Migrations
{
    public partial class BookmarkTimeStamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookmarkTimeStamp",
                table: "Bookmark",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookmarkTimeStamp",
                table: "Bookmark");
        }
    }
}
