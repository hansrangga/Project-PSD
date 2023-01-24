using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectPSD.Migrations
{
    public partial class DeffaultPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeffaultPrice",
                table: "Cart",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeffaultPrice",
                table: "Cart");
        }
    }
}
