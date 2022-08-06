namespace Consultorio.Models.Dto
{
	public class ProfissionalDetalhesDto
	{
		public string Nome { get; set; }
		public bool Ativo { get; set; }
		public int TotalConsultas { get; set; }
		public string[] Especialidades { get; set; }
	}
}