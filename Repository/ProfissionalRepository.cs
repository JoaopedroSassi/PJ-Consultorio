using Consultorio.Context;
using Consultorio.Models.Dto;
using Consultorio.Models.Entities;
using Consultorio.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.Repository
{
	public class ProfissionalRepository : BaseRepository, IProfissionalRepository
	{
		private readonly ConsultorioDbContext _context;

		public ProfissionalRepository(ConsultorioDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<IEnumerable<ProfissionalDto>> GetAllProfissionaisAsync()
			=> await _context
						.Profissionais
						.AsNoTracking()
						.Select(x => new ProfissionalDto(x.Id, x.Nome, x.Ativo))
						.ToListAsync();

		public async Task<Profissional> GetProfissionalByIdAsync(int id)
			=> await _context
						.Profissionais
						.AsNoTracking()
						.Include(x => x.Consultas)
						.Include(x => x.Especialidades)
						.FirstOrDefaultAsync(x => x.Id == id);
	}
}
