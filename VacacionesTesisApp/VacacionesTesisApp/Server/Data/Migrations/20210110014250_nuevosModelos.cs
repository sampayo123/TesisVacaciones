using Microsoft.EntityFrameworkCore.Migrations;

namespace VacacionesTesisApp.Server.Data.Migrations
{
    public partial class nuevosModelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailUsuario",
                table: "Empleados",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreUsuario",
                table: "Empleados",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailUsuario",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "NombreUsuario",
                table: "Empleados");
        }
    }
}
