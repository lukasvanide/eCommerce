using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    public partial class newtestinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "LocalUsers");

            migrationBuilder.AddColumn<string>(
                name: "AccessToken",
                table: "LocalUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessToken",
                table: "LocalUsers");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "LocalUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
