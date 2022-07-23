using Microsoft.EntityFrameworkCore.Migrations;

namespace Consultorio.Migrations
{
    public partial class AlternadoReferencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_tb_especialidade_EspecialidadeId",
                table: "tb_consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_tb_paciente_PacienteId",
                table: "tb_consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_tb_profissional_ProfissionalId",
                table: "tb_consulta");

            migrationBuilder.DropTable(
                name: "EspecialidadeProfissional");

            migrationBuilder.DropIndex(
                name: "IX_tb_consulta_EspecialidadeId",
                table: "tb_consulta");

            migrationBuilder.DropIndex(
                name: "IX_tb_consulta_PacienteId",
                table: "tb_consulta");

            migrationBuilder.DropIndex(
                name: "IX_tb_consulta_ProfissionalId",
                table: "tb_consulta");

            migrationBuilder.DropColumn(
                name: "EspecialidadeId",
                table: "tb_consulta");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "tb_consulta");

            migrationBuilder.DropColumn(
                name: "ProfissionalId",
                table: "tb_consulta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EspecialidadeId",
                table: "tb_consulta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "tb_consulta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfissionalId",
                table: "tb_consulta",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EspecialidadeProfissional",
                columns: table => new
                {
                    EspecialidadesId = table.Column<int>(type: "int", nullable: false),
                    ProfissionaisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecialidadeProfissional", x => new { x.EspecialidadesId, x.ProfissionaisId });
                    table.ForeignKey(
                        name: "FK_EspecialidadeProfissional_tb_especialidade_EspecialidadesId",
                        column: x => x.EspecialidadesId,
                        principalTable: "tb_especialidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EspecialidadeProfissional_tb_profissional_ProfissionaisId",
                        column: x => x.ProfissionaisId,
                        principalTable: "tb_profissional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_consulta_EspecialidadeId",
                table: "tb_consulta",
                column: "EspecialidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_consulta_PacienteId",
                table: "tb_consulta",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_consulta_ProfissionalId",
                table: "tb_consulta",
                column: "ProfissionalId");

            migrationBuilder.CreateIndex(
                name: "IX_EspecialidadeProfissional_ProfissionaisId",
                table: "EspecialidadeProfissional",
                column: "ProfissionaisId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_tb_especialidade_EspecialidadeId",
                table: "tb_consulta",
                column: "EspecialidadeId",
                principalTable: "tb_especialidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_tb_paciente_PacienteId",
                table: "tb_consulta",
                column: "PacienteId",
                principalTable: "tb_paciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_tb_profissional_ProfissionalId",
                table: "tb_consulta",
                column: "ProfissionalId",
                principalTable: "tb_profissional",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
