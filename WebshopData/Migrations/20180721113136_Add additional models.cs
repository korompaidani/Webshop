using Microsoft.EntityFrameworkCore.Migrations;

namespace WebshopData.Migrations
{
    public partial class Addadditionalmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryKind",
                table: "Products",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PersonEmail",
                table: "Products",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PersonName",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryKind = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryKind);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false),
                    PersonName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Email);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryKind",
                table: "Products",
                column: "CategoryKind");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PersonEmail",
                table: "Products",
                column: "PersonEmail");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryKind",
                table: "Products",
                column: "CategoryKind",
                principalTable: "Categories",
                principalColumn: "CategoryKind",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Persons_PersonEmail",
                table: "Products",
                column: "PersonEmail",
                principalTable: "Persons",
                principalColumn: "Email",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryKind",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Persons_PersonEmail",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryKind",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PersonEmail",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryKind",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PersonEmail",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PersonName",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
