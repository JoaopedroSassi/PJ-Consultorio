using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Consultorio.Models.Dto;
using Consultorio.Models.Dto.Paciente;
using Consultorio.Models.Entities;
using Consultorio.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PacienteController : ControllerBase
	{
		private readonly IPacienteRepository _repository;
		private readonly IMapper _mapper;

		public PacienteController(IPacienteRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<PacienteDto>> GetAsync()
		{
			IEnumerable<PacienteDto> pacientes = await _repository.GetAllPacientesAsync();

			if (pacientes.Any())
				return Ok(pacientes);
			else
				return BadRequest("Sem pacientes");
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<PacienteDetailsDto>> GetByIdAsync(int id)
		{
			Paciente paciente = await _repository.GetPacienteByIdAsync(id);

			PacienteDetailsDto pacienteRet = _mapper.Map<PacienteDetailsDto>(paciente);

			if (pacienteRet is not null)
				return Ok(pacienteRet);
			else
				return BadRequest("Paciente não encontrado");
		}
	}
}