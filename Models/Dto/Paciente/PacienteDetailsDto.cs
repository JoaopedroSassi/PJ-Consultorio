using System.Collections.Generic;
using Consultorio.Models.Entities;

namespace Consultorio.Models.Dto.Paciente
{
	public class PacienteDetailsDto
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Email { get; set; }
		public string Celular { get; set; }
		public List<Consulta> Consultas { get; set; }

		public PacienteDetailsDto(int id, string nome, string email, string celular, List<Consulta> consultas)
		{
			Id = id;
			Nome = nome;
			Email = email;
			Celular = celular;
			Consultas = consultas;
		}
	}
}