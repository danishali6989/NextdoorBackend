using Microsoft.EntityFrameworkCore.Migrations;

namespace NextDoor.DataLayer.Migrations
{
    public partial class cmntrmv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_NextDoorUser_User_id",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Post_Post_id",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_Post_id",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_User_id",
                table: "Comment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Comment_Post_id",
                table: "Comment",
                column: "Post_id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Post_Post_id",
                table: "Comment",
                column: "Post_id",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
