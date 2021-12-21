using Microsoft.EntityFrameworkCore.Migrations;

namespace NextDoor.DataLayer.Migrations
{
    public partial class pstfkcatid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Post_Category_id",
                table: "Post",
                column: "Category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Categories_Category_id",
                table: "Post",
                column: "Category_id",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Categories_Category_id",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_Category_id",
                table: "Post");
        }
    }
}
