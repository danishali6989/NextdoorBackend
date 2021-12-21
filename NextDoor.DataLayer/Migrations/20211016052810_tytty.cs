using Microsoft.EntityFrameworkCore.Migrations;

namespace NextDoor.DataLayer.Migrations
{
    public partial class tytty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PercentageCount",
                table: "PollResponse",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalCount",
                table: "PollResponse",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PercentageCount",
                table: "PollResponse");

            migrationBuilder.DropColumn(
                name: "TotalCount",
                table: "PollResponse");
        }
    }
}
