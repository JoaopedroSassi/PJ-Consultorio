using Microsoft.EntityFrameworkCore.Migrations;

namespace Consultorio.Migrations
{
    public partial class OneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "tb_consulta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tb_consulta_PacienteId",
                table: "tb_consulta",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_tb_paciente_PacienteId",
                table: "tb_consulta",
                column: "PacienteId",
                principalTable: "tb_paciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_tb_paciente_PacienteId",
                table: "tb_consulta");

            migrationBuilder.DropIndex(
                name: "IX_tb_consulta_PacienteId",
                table: "tb_consulta");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "tb_consulta");
        }
    }
}
