using AutoMapper;
using Consultorio.Models.Dto;
using Consultorio.Models.Entities;
using Consultorio.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EspecialidadeController : ControllerBase
	{
		private readonly IEspecialidadeRepository _repository;
		private readonly IMapper _mapper;

		public EspecialidadeController(IEspecialidadeRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<EspecialidadeDto>> GetAllAsync()
		{
			IEnumerable<EspecialidadeDto> especialidades = await _repository.GetAllEspecialidadesAsync();

			if (!especialidades.Any())
				return NotFound("Sem especialidades");

			return Ok(especialidades);
		}

		[HttpGet]
		[Route("{id:int}")]
		public async Task<ActionResult<EspecialidadeDetalhesDto>> GetByIdAsync(int id)
		{
			if (id <= 0)
				return NotFound("Id inválido");

			Especialidade especialidade = await _repository.GetEspecialidadeByIdAsync(id);

			EspecialidadeDetalhesDto especialidadeRet = _mapper.Map<EspecialidadeDetalhesDto>(especialidade);

			if (especialidadeRet is null)
				return NotFound("Especialidade inválida");

			return Ok(especialidadeRet);
		}

		[HttpPost]
		public async Task<ActionResult<EspecialidadeAdicionarDto>> PostAsync([FromBody] EspecialidadeAdicionarDto model)
		{
			if (!ModelState.IsValid)
				return BadRequest("Formato invalido");

			if (model is null)
				return BadRequest("Especialidade nula");

			Especialidade especialidade = new Especialidade(model.Nome, model.Ativa);

			_repository.Add(especialidade);
			if (!(await _repository.SaveChangesAsync()))
				return BadRequest("Erro ao salvar especialidade");

			return Ok("Especialidade adicionada");
		}

		[HttpPut]
		[Route("{id:int}")]
		public async Task<ActionResult<Especialidade>> PutAsync(int id, bool ativo)
		{
			if (id <= 0)
				return BadRequest("Id invalido");

			Especialidade especialidade = await _repository.GetEspecialidadeByIdAsync(id);

			especialidade.Ativa = ativo;

			_repository.Update(especialidade);
			if (!(await _repository.SaveChangesAsync()))
				return BadRequest("Erro ao atualizar especialidade");

			return Ok("Especialidade atualizada com sucesso!");
		}

		[HttpDelete]
		[Route("{id:int}")]
		public async Task<ActionResult<Especialidade>> DeleteAsync(int id)
		{
			if (id <= 0)
				return NotFound("Especialidade não encontrada");

			Especialidade especialidade = await _repository.GetEspecialidadeByIdAsync(id);

			if (especialidade is null)
				return NotFound("Especialidade não encontrada");

			_repository.Delete(especialidade);
			if (await _repository.SaveChangesAsync())
				return Ok("Especialidade removida");
			else
				return BadRequest("Erro ao remover especialidade");
		}
	}
}
