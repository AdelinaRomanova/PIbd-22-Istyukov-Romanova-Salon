using Microsoft.EntityFrameworkCore.Migrations;

namespace BeautySalonDatabaseImplement.Migrations
{
    public partial class InitialCreate42 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Purchases");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
