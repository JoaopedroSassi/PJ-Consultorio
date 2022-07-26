using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
		public async Task<ActionResult<Paciente>> GetAsync()
		{
			IEnumerable<Paciente> pacientes = await _repository.GetAllPacientesAsync();

			if (pacientes.Any())
				return Ok(pacientes);
			else
				return BadRequest("Sem pacientes");
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<Paciente>> GetByIdAsync(int id)
		{
			Paciente paciente = await _repository.GetPacienteByIdAsync(id);

			if (paciente is not null)
				return Ok(paciente);
			else
				return BadRequest("Paciente não encontrado");
		}
	}
}