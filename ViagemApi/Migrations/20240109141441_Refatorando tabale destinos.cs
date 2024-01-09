using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ViagemApi.Migrations
{
    /// <inheritdoc />
    public partial class Refatorandotabaledestinos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Destinos");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Destinos");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Destinos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FotoDetalhes",
                table: "Destinos",
                type: "varchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FotoPerfil",
                table: "Destinos",
                type: "varchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Meta",
                table: "Destinos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Destinos");

            migrationBuilder.DropColumn(
                name: "FotoDetalhes",
                table: "Destinos");

            migrationBuilder.DropColumn(
                name: "FotoPerfil",
                table: "Destinos");

            migrationBuilder.DropColumn(
                name: "Meta",
                table: "Destinos");

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Destinos",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Destinos",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
