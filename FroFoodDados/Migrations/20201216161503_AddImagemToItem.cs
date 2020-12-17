using Microsoft.EntityFrameworkCore.Migrations;

namespace FroFoodDados.Migrations
{
    public partial class AddImagemToItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeImagem",
                table: "Item",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeImagem",
                table: "Item");
        }
    }
}
