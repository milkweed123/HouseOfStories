using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseOfStories.Migrations
{
    public partial class AddColumn_IsValid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsValid",
                table: "Quotes",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsValid",
                table: "Quotes");
        }
    }
}
