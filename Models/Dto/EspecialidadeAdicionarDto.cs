namespace Consultorio.Models.Dto
{
	public class EspecialidadeAdicionarDto
	{
		public string Nome { get; set; }
		public bool Ativa { get; set; }

		public EspecialidadeAdicionarDto(string nome, bool ativa)
		{
			Nome = nome;
			Ativa = ativa;
		}
	}
}