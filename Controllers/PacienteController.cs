using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Consultorio.Models.Entities;
using Consultorio.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
		public ActionResult<Paciente> Get()
		{
			IEnumerable<Paciente> pacientes = _repository.GetAll();

			if (pacientes.Any())
				return Ok(pacientes);
			else
				return BadRequest("Sem pacientes");
		}

		[HttpGet("{id:int}")]
		public ActionResult<Paciente> GetById(int id)
		{
			Paciente paciente = _repository.GetById(id);

			if (paciente is not null)
				return Ok(paciente);
			else
				return BadRequest("Paciente não encontrado");
		}
	}
}