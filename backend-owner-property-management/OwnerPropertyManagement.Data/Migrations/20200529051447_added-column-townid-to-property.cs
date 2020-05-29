using Microsoft.EntityFrameworkCore.Migrations;

namespace OwnerPropertyManagement.Data.Migrations
{
    public partial class addedcolumntownidtoproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TownId",
                table: "Property",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Property_TownId",
                table: "Property",
                column: "TownId");

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Town_TownId",
                table: "Property",
                column: "TownId",
                principalTable: "Town",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Property_Town_TownId",
                table: "Property");

            migrationBuilder.DropIndex(
                name: "IX_Property_TownId",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "TownId",
                table: "Property");
        }
    }
}
