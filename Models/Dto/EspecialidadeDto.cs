namespace Consultorio.Models.Dto
{
    public class EspecialidadeDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativa { get; set; }

        public EspecialidadeDto(int id, string nome, bool ativa)
        {
            Id = id;
            Nome = nome;
            Ativa = ativa;
        }
    }
}
