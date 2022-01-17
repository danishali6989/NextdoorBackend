using Microsoft.EntityFrameworkCore.Migrations;

namespace NextDoor.DataLayer.Migrations
{
    public partial class eventuseridfkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Event_User_ID",
                table: "Event",
                column: "User_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_NextDoorUser_User_ID",
                table: "Event",
                column: "User_ID",
                principalTable: "NextDoorUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_NextDoorUser_User_ID",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_User_ID",
                table: "Event");
        }
    }
}
