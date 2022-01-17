using Microsoft.EntityFrameworkCore.Migrations;

namespace NextDoor.DataLayer.Migrations
{
    public partial class polluseridfkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Poll_UserID",
                table: "Poll",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Poll_NextDoorUser_UserID",
                table: "Poll",
                column: "UserID",
                principalTable: "NextDoorUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Poll_NextDoorUser_UserID",
                table: "Poll");

            migrationBuilder.DropIndex(
                name: "IX_Poll_UserID",
                table: "Poll");
        }
    }
}
