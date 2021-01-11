using Microsoft.EntityFrameworkCore.Migrations;

namespace VacacionesTesisApp.Server.Data.Migrations
{
    public partial class direccionyEstatusBorrado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicituds_Estatus_EstatusId",
                table: "Solicituds");

            migrationBuilder.DropIndex(
                name: "IX_Solicituds_EstatusId",
                table: "Solicituds");

            migrationBuilder.DropColumn(
                name: "EstatusId",
                table: "Solicituds");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Empleados");

            migrationBuilder.AddColumn<string>(
                name: "Estatus",
                table: "Solicituds",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estatus",
                table: "Solicituds");

            migrationBuilder.AddColumn<string>(
                name: "EstatusId",
                table: "Solicituds",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Empleados",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Solicituds_EstatusId",
                table: "Solicituds",
                column: "EstatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Solicituds_Estatus_EstatusId",
                table: "Solicituds",
                column: "EstatusId",
                principalTable: "Estatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
