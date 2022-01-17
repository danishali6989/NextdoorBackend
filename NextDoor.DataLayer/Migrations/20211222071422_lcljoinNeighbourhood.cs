using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NextDoor.DataLayer.Migrations
{
    public partial class lcljoinNeighbourhood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JoinNeighbourhood",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NeighbourhoodId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JoinNeighbourhood", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JoinNeighbourhood_Neighbourhood_NeighbourhoodId",
                        column: x => x.NeighbourhoodId,
                        principalTable: "Neighbourhood",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JoinNeighbourhood_NeighbourhoodId",
                table: "JoinNeighbourhood",
                column: "NeighbourhoodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JoinNeighbourhood");
        }
    }
}
