using Microsoft.EntityFrameworkCore.Migrations;

namespace Consultorio.Migrations
{
    public partial class AlterandoAgendamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Agendamentos",
                table: "Agendamentos");

            migrationBuilder.RenameTable(
                name: "Agendamentos",
                newName: "tb_agendamento");

            migrationBuilder.AlterColumn<string>(
                name: "NomePaciente",
                table: "tb_agendamento",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_agendamento",
                table: "tb_agendamento",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_agendamento",
                table: "tb_agendamento");

            migrationBuilder.RenameTable(
                name: "tb_agendamento",
                newName: "Agendamentos");

            migrationBuilder.AlterColumn<string>(
                name: "NomePaciente",
                table: "Agendamentos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agendamentos",
                table: "Agendamentos",
                column: "Id");
        }
    }
}
