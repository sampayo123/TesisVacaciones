using Microsoft.EntityFrameworkCore.Migrations;

namespace VacacionesTesisApp.Server.Data.Migrations
{
    public partial class relacionEmpleadoSolicitud : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmpleadoId",
                table: "Solicituds",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Solicituds_EmpleadoId",
                table: "Solicituds",
                column: "EmpleadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Solicituds_Empleados_EmpleadoId",
                table: "Solicituds",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicituds_Empleados_EmpleadoId",
                table: "Solicituds");

            migrationBuilder.DropIndex(
                name: "IX_Solicituds_EmpleadoId",
                table: "Solicituds");

            migrationBuilder.DropColumn(
                name: "EmpleadoId",
                table: "Solicituds");
        }
    }
}
