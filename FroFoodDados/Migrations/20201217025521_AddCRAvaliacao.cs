using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FroFoodDados.Migrations
{
    public partial class AddCRAvaliacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClienteId",
                table: "Avaliacao",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RestauranteId",
                table: "Avaliacao",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_ClienteId",
                table: "Avaliacao",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_RestauranteId",
                table: "Avaliacao",
                column: "RestauranteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacao_Cliente_ClienteId",
                table: "Avaliacao",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacao_Restaurantes_RestauranteId",
                table: "Avaliacao",
                column: "RestauranteId",
                principalTable: "Restaurantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacao_Cliente_ClienteId",
                table: "Avaliacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacao_Restaurantes_RestauranteId",
                table: "Avaliacao");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacao_ClienteId",
                table: "Avaliacao");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacao_RestauranteId",
                table: "Avaliacao");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Avaliacao");

            migrationBuilder.DropColumn(
                name: "RestauranteId",
                table: "Avaliacao");
        }
    }
}
