using Microsoft.EntityFrameworkCore.Migrations;

namespace NextDoor.DataLayer.Migrations
{
    public partial class fkdcomment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Comment_User_id",
                table: "Comment",
                column: "User_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_NextDoorUser_User_id",
                table: "Comment",
                column: "User_id",
                principalTable: "NextDoorUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_NextDoorUser_User_id",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_User_id",
                table: "Comment");
        }
    }
}
