namespace Consultorio.Models.Dto
{
	public class PacienteDto
	{
		public int Id { get; set; }
		public string Nome { get; set; }

		public PacienteDto(int id, string nome)
		{
			Id = id;
			Nome = nome;
		}
	}
}