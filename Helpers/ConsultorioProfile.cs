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
		}
	}
}