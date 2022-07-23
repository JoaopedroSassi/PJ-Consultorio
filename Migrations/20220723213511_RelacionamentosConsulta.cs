using Microsoft.EntityFrameworkCore.Migrations;

namespace Consultorio.Migrations
{
    public partial class RelacionamentosConsulta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EspecialidadeId",
                table: "tb_consulta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProfissionalId",
                table: "tb_consulta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tb_consulta_EspecialidadeId",
                table: "tb_consulta",
                column: "EspecialidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_consulta_ProfissionalId",
                table: "tb_consulta",
                column: "ProfissionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_tb_especialidade_EspecialidadeId",
                table: "tb_consulta",
                column: "EspecialidadeId",
                principalTable: "tb_especialidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_tb_profissional_ProfissionalId",
                table: "tb_consulta",
                column: "ProfissionalId",
                principalTable: "tb_profissional",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_tb_especialidade_EspecialidadeId",
                table: "tb_consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_tb_profissional_ProfissionalId",
                table: "tb_consulta");

            migrationBuilder.DropIndex(
                name: "IX_tb_consulta_EspecialidadeId",
                table: "tb_consulta");

            migrationBuilder.DropIndex(
                name: "IX_tb_consulta_ProfissionalId",
                table: "tb_consulta");

            migrationBuilder.DropColumn(
                name: "EspecialidadeId",
                table: "tb_consulta");

            migrationBuilder.DropColumn(
                name: "ProfissionalId",
                table: "tb_consulta");
        }
    }
}
