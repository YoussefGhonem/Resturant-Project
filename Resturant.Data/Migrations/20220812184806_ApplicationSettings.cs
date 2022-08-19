using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant.Data.Migrations
{
    public partial class ApplicationSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ApplicationSettings");

            migrationBuilder.CreateTable(
                name: "Settings",
                schema: "ApplicationSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutUs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrivateDiningDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkWithUsDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailService = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberService = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrivateDiningAttachmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrivateDiningAttachmentPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings",
                schema: "ApplicationSettings");
        }
    }
}
