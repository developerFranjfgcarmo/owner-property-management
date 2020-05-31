using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OwnerPropertyManagement.Data.Migrations
{
    public partial class removeaudittable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "UserCreated",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "UserUpdated",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Owner");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Owner");

            migrationBuilder.DropColumn(
                name: "UserCreated",
                table: "Owner");

            migrationBuilder.DropColumn(
                name: "UserUpdated",
                table: "Owner");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Property",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Property",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserCreated",
                table: "Property",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserUpdated",
                table: "Property",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Owner",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Owner",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserCreated",
                table: "Owner",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserUpdated",
                table: "Owner",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
