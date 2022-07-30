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
		}
	}
}