using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FroFoodDados.Migrations
{
    public partial class addMuitosEnderecos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Endereco_EnderecoId",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_EnderecoId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Cliente");

            migrationBuilder.AddColumn<Guid>(
                name: "ClienteId",
                table: "Endereco",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_ClienteId",
                table: "Endereco",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Cliente_ClienteId",
                table: "Endereco",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Cliente_ClienteId",
                table: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_ClienteId",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Endereco");

            migrationBuilder.AddColumn<Guid>(
                name: "EnderecoId",
                table: "Cliente",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_EnderecoId",
                table: "Cliente",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Endereco_EnderecoId",
                table: "Cliente",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
