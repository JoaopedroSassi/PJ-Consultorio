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
	public class ProfissionalController : ControllerBase
	{
		private readonly IProfissionalRepository _repository;
		private readonly IMapper _mapper;

		public ProfissionalController(IProfissionalRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<ProfissionalDto>> GetAsync()
		{
			IEnumerable<ProfissionalDto> profissionais = await _repository.GetAllProfissionaisAsync();

			if (profissionais.Any())
				return Ok(profissionais);
			else
				return BadRequest("Nenhum profissional");
		}

		[HttpGet]
		[Route("{id:int}")]
		public async Task<ActionResult<ProfissionalDetalhesDto>> GetByIdAsync(int id)
		{
			if (id <= 0)
				return NotFound("Id invalido");

			Profissional profissional = await _repository.GetProfissionalByIdAsync(id);

			ProfissionalDetalhesDto profissionalRetorno = _mapper.Map<ProfissionalDetalhesDto>(profissional);

			if (profissionalRetorno is null)
				return NotFound("Profissional não encontrado");

			return Ok(profissionalRetorno);
		}

		[HttpPost]
		public async Task<ActionResult<ProfissionalDetalhesDto>> PostAsync([FromBody] ProfissionalAdicionarDto model)
		{
			if (!ModelState.IsValid)
				return BadRequest("Formato invalido");

			if (model is null)
				return BadRequest("Profissional nulo");

			Profissional profissionalAdicionar = _mapper.Map<Profissional>(model);

			_repository.Add(profissionalAdicionar);
			if (await _repository.SaveChangesAsync())
				return Ok("Profissional adicionado");
			else
				return BadRequest("Erro ao adicionar profissional");
		}

		[HttpPut]
		[Route("{id:int}")]
		public async Task<ActionResult<ProfissionalAtualizarDto>> PutAsync(int id, [FromBody] ProfissionalAtualizarDto model)
		{
			if (!ModelState.IsValid)
				return BadRequest("Formato invalido");

			if (model is null)
				return BadRequest("Profissional nulo");

			if (id <= 0)
				return NotFound("Id invalido");

			Profissional profissional = await _repository.GetProfissionalByIdAsync(id);

			if (profissional is null)
				return NotFound("Dados invalidos");

			Profissional profissionalAtuali = _mapper.Map(model, profissional);

			_repository.Update(profissionalAtuali);
			if (await _repository.SaveChangesAsync())
				return Ok("Profissional atualizado");
			else
				return BadRequest("Erro ao atualizar profissional");
		}

		[HttpDelete]
		[Route("{id:int}")]
		public async Task<ActionResult<Profissional>> DeleteAsync(int id)
		{
			if (id <= 0)
				return NotFound("Profissional não encontrado");

			Profissional profissional = await _repository.GetProfissionalByIdAsync(id);

			if (profissional is null)
				return NotFound("Profissional não encontrado");

			_repository.Delete(profissional);
			if (await _repository.SaveChangesAsync())
				return Ok("Profissional removido");
			else
				return BadRequest("Erro ao remover profissional");
		}
	}
}
