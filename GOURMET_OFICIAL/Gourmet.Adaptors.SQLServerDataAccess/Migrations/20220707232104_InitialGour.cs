using Microsoft.EntityFrameworkCore.Migrations;

namespace Gourmet.Adaptors.SQLServerDataAccess.Migrations
{
    public partial class InitialGour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "tb_Plato");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "tb_CategoriaPlato");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "tb_CategoriaBebida");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "tb_Bebida");

            migrationBuilder.AddColumn<string>(
                name: "NombreP",
                table: "tb_Plato",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoriaP",
                table: "tb_CategoriaPlato",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoriaB",
                table: "tb_CategoriaBebida",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreB",
                table: "tb_Bebida",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreP",
                table: "tb_Plato");

            migrationBuilder.DropColumn(
                name: "CategoriaP",
                table: "tb_CategoriaPlato");

            migrationBuilder.DropColumn(
                name: "CategoriaB",
                table: "tb_CategoriaBebida");

            migrationBuilder.DropColumn(
                name: "NombreB",
                table: "tb_Bebida");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "tb_Plato",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "tb_CategoriaPlato",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "tb_CategoriaBebida",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "tb_Bebida",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
