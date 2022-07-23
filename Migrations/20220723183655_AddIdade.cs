using Microsoft.EntityFrameworkCore.Migrations;

namespace Consultorio.Migrations
{
    public partial class AddIdade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "Agendamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Idade",
                table: "Agendamentos");
        }
    }
}
