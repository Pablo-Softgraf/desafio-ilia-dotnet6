using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio_Ilia_PARR.Migrations
{
    public partial class AddAlocacaoDataTableOnDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_product",
                table: "product");

            migrationBuilder.RenameTable(
                name: "product",
                newName: "alocacao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_alocacao",
                table: "alocacao",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_alocacao",
                table: "alocacao");

            migrationBuilder.RenameTable(
                name: "alocacao",
                newName: "product");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product",
                table: "product",
                column: "Id");
        }
    }
}
