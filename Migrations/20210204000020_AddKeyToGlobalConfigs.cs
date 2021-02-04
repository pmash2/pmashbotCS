using Microsoft.EntityFrameworkCore.Migrations;

namespace pmashbotCS.Migrations
{
    public partial class AddKeyToGlobalConfigs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "GlobalConfigs",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                table: "GlobalConfigs");
        }
    }
}
