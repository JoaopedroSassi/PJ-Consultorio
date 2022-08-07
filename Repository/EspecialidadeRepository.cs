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
	public class EspecialidadeRepository : BaseRepository, IEspecialidadeRepository
	{
		private readonly ConsultorioDbContext _context;

		public EspecialidadeRepository(ConsultorioDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<IEnumerable<EspecialidadeDto>> GetAllEspecialidadesAsync()
			=> await _context
					 .Especialidades
					 .AsNoTracking()
					 .Select(x => new EspecialidadeDto(x.Id, x.Nome, x.Ativa))
					 .ToListAsync();

		public async Task<Especialidade> GetEspecialidadeByIdAsync(int id)
			=> await _context
						.Especialidades
						.AsNoTracking()
						.Include(x => x.Profissionais)
						.FirstOrDefaultAsync(x => x.Id == id);
	}
}
