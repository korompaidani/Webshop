using Microsoft.EntityFrameworkCore.Migrations;

namespace WebshopData.Migrations
{
    public partial class ModifyProductstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonName",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PersonName",
                table: "Products",
                nullable: true);
        }
    }
}
