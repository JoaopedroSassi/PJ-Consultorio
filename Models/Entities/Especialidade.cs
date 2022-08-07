using System.Collections.Generic;

namespace Consultorio.Models.Entities
{
	public class Especialidade : Base
	{
		public string Nome { get; set; }
		public bool Ativa { get; set; }
		public List<Consulta> Consultas { get; set; }
		public List<Profissional> Profissionais { get; set; }

		public Especialidade(string nome, bool ativa)
		{
			Nome = nome;
			Ativa = ativa;
		}
	}
}