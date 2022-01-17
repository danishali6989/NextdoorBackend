using Microsoft.EntityFrameworkCore.Migrations;

namespace NextDoor.DataLayer.Migrations
{
    public partial class PostUseridFkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Post_User_id",
                table: "Post",
                column: "User_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_NextDoorUser_User_id",
                table: "Post",
                column: "User_id",
                principalTable: "NextDoorUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_NextDoorUser_User_id",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_User_id",
                table: "Post");
        }
    }
}
