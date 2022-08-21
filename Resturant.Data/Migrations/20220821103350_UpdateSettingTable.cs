using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant.Data.Migrations
{
    public partial class UpdateSettingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutAttachmentName",
                schema: "ApplicationSettings",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutAttachmentPath",
                schema: "ApplicationSettings",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManuAttachmentName",
                schema: "ApplicationSettings",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManuAttachmentPath",
                schema: "ApplicationSettings",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "privateDiningCoverAttachmentName",
                schema: "ApplicationSettings",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "privateDiningCoverAttachmentPath",
                schema: "ApplicationSettings",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutAttachmentName",
                schema: "ApplicationSettings",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "AboutAttachmentPath",
                schema: "ApplicationSettings",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ManuAttachmentName",
                schema: "ApplicationSettings",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ManuAttachmentPath",
                schema: "ApplicationSettings",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "privateDiningCoverAttachmentName",
                schema: "ApplicationSettings",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "privateDiningCoverAttachmentPath",
                schema: "ApplicationSettings",
                table: "Settings");
        }
    }
}
