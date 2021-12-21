using Microsoft.EntityFrameworkCore.Migrations;

namespace NextDoor.DataLayer.Migrations
{
    public partial class selji : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonSafety",
                table: "PersonSafety");

            migrationBuilder.RenameTable(
                name: "PersonSafety",
                newName: "VechileSafety");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VechileSafety",
                table: "VechileSafety",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VechileSafety",
                table: "VechileSafety");

            migrationBuilder.RenameTable(
                name: "VechileSafety",
                newName: "PersonSafety");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonSafety",
                table: "PersonSafety",
                column: "Id");
        }
    }
}
