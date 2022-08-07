using System.Linq;
using AutoMapper;
using Consultorio.Models.Dto;
using Consultorio.Models.Entities;

namespace Consultorio.Helpers
{
	public class ConsultorioProfile : Profile
	{
		public ConsultorioProfile()
		{
			CreateMap<Paciente, PacienteDetailsDto>();
			CreateMap<Consulta, ConsultaDto>()
				.ForMember(x => x.Especialidade, y => y.MapFrom(x => x.Especialidade.Nome))
				.ForMember(x => x.Profissional, y => y.MapFrom(x => x.Profissional.Nome));

			CreateMap<PacienteAdicionarDto, Paciente>();
			CreateMap<PacienteAtualizarDto, Paciente>()
				.ForAllMembers(x => x.Condition((x, y, z) => z != null));

			CreateMap<Profissional, ProfissionalDetalhesDto>()
				.ForMember(x => x.TotalConsultas, y => y.MapFrom(z => z.Consultas.Count()))
				.ForMember(x => x.Especialidades, y => y.MapFrom(z => z.Especialidades.Select(n => n.Nome).ToArray()));

			CreateMap<Profissional, ProfissionalDto>();

			CreateMap<ProfissionalAdicionarDto, Profissional>();

			CreateMap<ProfissionalAtualizarDto, Profissional>()
				.ForAllMembers(x => x.Condition((x, y, z) => z != null));


			CreateMap<Especialidade, EspecialidadeDetalhesDto>();
		}
	}
}