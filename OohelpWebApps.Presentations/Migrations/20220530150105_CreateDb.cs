using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OohelpWebApps.Presentations.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Presentations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShowOwner = table.Column<bool>(type: "bit", nullable: false),
                    ColumnPrice = table.Column<bool>(type: "bit", nullable: false),
                    ColumnSupplier = table.Column<bool>(type: "bit", nullable: false),
                    ColumnGrp = table.Column<bool>(type: "bit", nullable: false),
                    ColumnCondition = table.Column<bool>(type: "bit", nullable: false),
                    CardType = table.Column<bool>(type: "bit", nullable: false),
                    CardSide = table.Column<bool>(type: "bit", nullable: false),
                    CardPrice = table.Column<bool>(type: "bit", nullable: false),
                    CardMedia = table.Column<bool>(type: "bit", nullable: false),
                    CardSupplier = table.Column<bool>(type: "bit", nullable: false),
                    CardCode = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presentations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Supplier = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    City = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Side = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: false),
                    Size = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    Lighting = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Angle = table.Column<int>(type: "int", nullable: true),
                    DoorsDix = table.Column<int>(type: "int", nullable: true),
                    Ots = table.Column<int>(type: "int", nullable: true),
                    Grp = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Condition = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IconColor = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: true),
                    IconStyle = table.Column<int>(type: "int", nullable: false),
                    PresentationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boards_Presentations_PresentationId",
                        column: x => x.PresentationId,
                        principalTable: "Presentations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pois",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    IconColor = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: true),
                    IconStyle = table.Column<int>(type: "int", nullable: false),
                    PresentationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pois", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pois_Presentations_PresentationId",
                        column: x => x.PresentationId,
                        principalTable: "Presentations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boards_PresentationId",
                table: "Boards",
                column: "PresentationId");

            migrationBuilder.CreateIndex(
                name: "IX_Pois_PresentationId",
                table: "Pois",
                column: "PresentationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DropTable(
                name: "Pois");

            migrationBuilder.DropTable(
                name: "Presentations");
        }
    }
}
