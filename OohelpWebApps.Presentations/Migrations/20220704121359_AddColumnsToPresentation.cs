using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OohelpWebApps.Presentations.Migrations
{
    public partial class AddColumnsToPresentation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ColumnAddress",
                table: "Presentations",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "ColumnCity",
                table: "Presentations",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "ColumnSupplierCode",
                table: "Presentations",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "ColumnTypeSize",
                table: "Presentations",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColumnAddress",
                table: "Presentations");

            migrationBuilder.DropColumn(
                name: "ColumnCity",
                table: "Presentations");

            migrationBuilder.DropColumn(
                name: "ColumnSupplierCode",
                table: "Presentations");

            migrationBuilder.DropColumn(
                name: "ColumnTypeSize",
                table: "Presentations");
        }
    }
}
