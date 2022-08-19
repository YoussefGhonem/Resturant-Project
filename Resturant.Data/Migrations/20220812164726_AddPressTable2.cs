using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant.Data.Migrations
{
    public partial class AddPressTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AttachmentExtension",
                schema: "Business",
                table: "Press",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AttachmentName",
                schema: "Business",
                table: "Press",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AttachmentPath",
                schema: "Business",
                table: "Press",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttachmentExtension",
                schema: "Business",
                table: "Press");

            migrationBuilder.DropColumn(
                name: "AttachmentName",
                schema: "Business",
                table: "Press");

            migrationBuilder.DropColumn(
                name: "AttachmentPath",
                schema: "Business",
                table: "Press");
        }
    }
}
