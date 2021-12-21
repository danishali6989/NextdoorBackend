using Microsoft.EntityFrameworkCore.Migrations;

namespace NextDoor.DataLayer.Migrations
{
    public partial class atch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AttachmentType",
                table: "Comment",
                newName: "AttachmentType3");

            migrationBuilder.AddColumn<string>(
                name: "AttachmentType1",
                table: "Comment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AttachmentType2",
                table: "Comment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttachmentType1",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "AttachmentType2",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "AttachmentType3",
                table: "Comment",
                newName: "AttachmentType");
        }
    }
}
