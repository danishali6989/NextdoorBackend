using Microsoft.EntityFrameworkCore.Migrations;

namespace NextDoor.DataLayer.Migrations
{
    public partial class neighbourhoodtimestamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NeighbourhoodTimeStamp",
                table: "Neighbourhood",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NeighbourhoodTimeStamp",
                table: "Neighbourhood");
        }
    }
}
