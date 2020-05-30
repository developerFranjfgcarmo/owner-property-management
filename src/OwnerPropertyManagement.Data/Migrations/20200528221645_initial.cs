using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OwnerPropertyManagement.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    UserCreated = table.Column<string>(nullable: true),
                    UserUpdated = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    Surname = table.Column<string>(maxLength: 50, nullable: true),
                    Nick = table.Column<string>(maxLength: 50, nullable: true),
                    PersonalPhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    ContactPhoneProperty = table.Column<string>(maxLength: 20, nullable: true),
                    Street = table.Column<string>(maxLength: 150, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 5, nullable: true),
                    City = table.Column<string>(maxLength: 100, nullable: true),
                    Country = table.Column<string>(maxLength: 100, nullable: true),
                    AboutMe = table.Column<string>(maxLength: 500, nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypesFacility",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesFacility", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zone",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    UserCreated = table.Column<string>(nullable: true),
                    UserUpdated = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    Sleeps = table.Column<short>(nullable: false),
                    Bedrooms = table.Column<short>(nullable: false),
                    Bathrooms = table.Column<short>(nullable: false),
                    PrivatePool = table.Column<bool>(nullable: false),
                    HeatedPool = table.Column<bool>(nullable: false),
                    Wifi = table.Column<bool>(nullable: false),
                    Garden = table.Column<bool>(nullable: false),
                    LivingArea = table.Column<int>(nullable: false),
                    DistanceAirport = table.Column<short>(nullable: false),
                    DistanceBeach = table.Column<short>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LocalLeisure = table.Column<string>(maxLength: 250, nullable: true),
                    LocalActivities = table.Column<string>(maxLength: 250, nullable: true),
                    OwnerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Property_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facility",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    TypeFacilityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facility", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facility_TypesFacility_TypeFacilityId",
                        column: x => x.TypeFacilityId,
                        principalTable: "TypesFacility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Town",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    ZoneId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Town", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Town_Zone_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyFacility",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyId = table.Column<int>(nullable: false),
                    FacilityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyFacility", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyFacility_Facility_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyFacility_Property_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Property",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TypesFacility",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "General" },
                    { 2, "Outside" },
                    { 3, "Inside" },
                    { 4, "Kitchen" },
                    { 5, "Bathroom" },
                    { 6, "Views" },
                    { 7, "Relevant information" }
                });

            migrationBuilder.InsertData(
                table: "Zone",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Costa del Sol" },
                    { 2, "Costa Brava" },
                    { 3, "Costa Blanco" }
                });

            migrationBuilder.InsertData(
                table: "Facility",
                columns: new[] { "Id", "Description", "TypeFacilityId" },
                values: new object[,]
                {
                    { 1, "Beach towels", 1 },
                    { 23, "Hob", 4 },
                    { 24, "Microwave", 4 },
                    { 25, "Jacuzzi", 5 },
                    { 26, "Shower", 5 },
                    { 27, "Bath tub", 5 },
                    { 28, "Hair dryer", 5 },
                    { 29, "Sea views", 6 },
                    { 30, "Mountain views", 6 },
                    { 31, "Pool views", 6 },
                    { 32, "Wheelchair accessible", 7 },
                    { 33, "Suitable for the elderly", 7 },
                    { 34, "Pets considered", 7 },
                    { 35, "No smoking inside", 7 },
                    { 36, "Car not necessary", 7 },
                    { 37, "Car recommended", 7 },
                    { 21, "Coffee machine", 4 },
                    { 20, "Fridge", 4 },
                    { 22, "Grill", 4 },
                    { 18, "Dishwasher", 4 },
                    { 2, "Linen", 1 },
                    { 3, "Towels", 1 },
                    { 4, "Private pool", 2 },
                    { 5, "Heated pool", 2 },
                    { 6, "Outside jacuzzi", 2 },
                    { 19, "Freezer", 4 },
                    { 8, "Parking", 2 },
                    { 9, "Barbecue", 2 },
                    { 7, "Garden", 2 },
                    { 11, "Wi-Fi", 3 },
                    { 12, "Satellite", 3 },
                    { 13, "Tv", 3 },
                    { 14, "Cot", 3 },
                    { 15, "Iron", 3 },
                    { 16, "Safe", 3 },
                    { 17, "Air conditioning", 3 },
                    { 10, "Sunbeds", 2 }
                });

            migrationBuilder.InsertData(
                table: "Town",
                columns: new[] { "Id", "Description", "ZoneId" },
                values: new object[,]
                {
                    { 6, "Denia", 3 },
                    { 1, "Fuenguirola", 1 },
                    { 2, "Estepona", 1 },
                    { 3, "Benalmadena", 1 },
                    { 4, "Begur", 2 },
                    { 5, "Blanes", 2 },
                    { 7, "Altea", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Facility_TypeFacilityId",
                table: "Facility",
                column: "TypeFacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Property_OwnerId",
                table: "Property",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyFacility_FacilityId",
                table: "PropertyFacility",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyFacility_PropertyId",
                table: "PropertyFacility",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Town_ZoneId",
                table: "Town",
                column: "ZoneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyFacility");

            migrationBuilder.DropTable(
                name: "Town");

            migrationBuilder.DropTable(
                name: "Facility");

            migrationBuilder.DropTable(
                name: "Property");

            migrationBuilder.DropTable(
                name: "Zone");

            migrationBuilder.DropTable(
                name: "TypesFacility");

            migrationBuilder.DropTable(
                name: "Owner");
        }
    }
}
