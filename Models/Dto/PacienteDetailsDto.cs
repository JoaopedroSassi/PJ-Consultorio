using System.Collections.Generic;

namespace Consultorio.Models.Dto
{
	public class PacienteDetailsDto
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Email { get; set; }
		public string Celular { get; set; }
		public List<ConsultaDto> Consultas { get; set; }

		public PacienteDetailsDto(int id, string nome, string email, string celular, List<ConsultaDto> consultas)
		{
			Id = id;
			Nome = nome;
			Email = email;
			Celular = celular;
			Consultas = consultas;
		}
	}
}