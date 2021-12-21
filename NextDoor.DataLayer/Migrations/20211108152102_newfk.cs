using Microsoft.EntityFrameworkCore.Migrations;

namespace NextDoor.DataLayer.Migrations
{
    public partial class newfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Post_ListingCategoryId",
                table: "Post",
                column: "ListingCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_ListingCategories_ListingCategoryId",
                table: "Post",
                column: "ListingCategoryId",
                principalTable: "ListingCategories",
                principalColumn: "ListingCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_ListingCategories_ListingCategoryId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_ListingCategoryId",
                table: "Post");
        }
    }
}
