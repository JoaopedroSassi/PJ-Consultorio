using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

		public PacienteController(IPacienteRepository repository)
		{
			_repository = repository;
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
		public async Task<ActionResult<Paciente>> GetByIdAsync(int id)
		{
			Paciente paciente = await _repository.GetPacienteByIdAsync(id);

			PacienteDetailsDto pacienteRet = new PacienteDetailsDto(paciente.Id, paciente.Nome, paciente.Email, paciente.Celular, paciente.Consultas);

			if (pacienteRet is not null)
				return Ok(pacienteRet);
			else
				return BadRequest("Paciente não encontrado");
		}
	}
}