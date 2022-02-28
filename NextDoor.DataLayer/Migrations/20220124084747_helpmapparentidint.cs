using Microsoft.EntityFrameworkCore.Migrations;

namespace NextDoor.DataLayer.Migrations
{
    public partial class helpmapparentidint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentMessage",
                table: "HelpMap");

            migrationBuilder.AddColumn<int>(
                name: "ParentMessageId",
                table: "HelpMap",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentMessageId",
                table: "HelpMap");

            migrationBuilder.AddColumn<string>(
                name: "ParentMessage",
                table: "HelpMap",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
