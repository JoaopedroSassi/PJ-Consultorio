using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Consultorio.Models.Dto;
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

		[HttpPost]
		public async Task<ActionResult<Paciente>> Post([FromBody] PacienteAdicionarDto model)
		{
			if (!ModelState.IsValid)
				return BadRequest("Paciente inválido");

			if (model is null)
				return BadRequest("Paciente nulo");

			Paciente pacienteAdd = _mapper.Map<Paciente>(model);

			_repository.Add(pacienteAdd);
			if (!(await _repository.SaveChangesAsync()))
				return BadRequest("Erro ao salvar paciente");

			return Ok("Paciente adicionado com sucesso!");
		}

		[HttpPut("{id:int}")]
		public async Task<ActionResult<Paciente>> Put(int id, [FromBody] PacienteAtualizarDto model)
		{
			if (id <= 0)
				return NotFound("Paciente não encontrado");

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			Paciente paciente = await _repository.GetPacienteByIdAsync(id);
			paciente = _mapper.Map(model, paciente);

			_repository.Update(paciente);
			if (!(await _repository.SaveChangesAsync()))
				return BadRequest("Erro ao atualizar paciente");

			return Ok("Paciente atualizado com sucesso!");
		}

		[HttpDelete("{id:int}")]
		public async Task<ActionResult<Paciente>> Delete(int id)
		{
			if (id <= 0)
				return NotFound("Paciente não encontrado");

			Paciente paciente = await _repository.GetPacienteByIdAsync(id);

			if (paciente is null)
				return BadRequest("Paciente inválido");

			_repository.Delete(paciente);
			if (!(await _repository.SaveChangesAsync()))
				return BadRequest("Erro ao deletar paciente");

			return Ok("Paciente deletado com sucesso!");
		}
	}
}