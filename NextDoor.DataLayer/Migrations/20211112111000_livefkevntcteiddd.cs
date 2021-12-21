using Microsoft.EntityFrameworkCore.Migrations;

namespace NextDoor.DataLayer.Migrations
{
    public partial class livefkevntcteiddd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Event_EventCategoryId",
                table: "Event",
                column: "EventCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_EventCategories_EventCategoryId",
                table: "Event",
                column: "EventCategoryId",
                principalTable: "EventCategories",
                principalColumn: "EventCategory_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_EventCategories_EventCategoryId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_EventCategoryId",
                table: "Event");
        }
    }
}
