using System.Collections.Generic;
using System.Threading.Tasks;
using Consultorio.Context;
using Consultorio.Models.Entities;
using Consultorio.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Repository
{
	public class PacienteRepository : BaseRepository, IPacienteRepository
	{
		private readonly ConsultorioDbContext _context;

		public PacienteRepository(ConsultorioDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Paciente>> GetAllPacientesAsync()
			=> await _context.Pacientes.AsNoTracking().Include(x => x.Consultas).ToListAsync();

		public async Task<Paciente> GetPacienteByIdAsync(int id)
		{
			Paciente paciente = await _context.Pacientes.AsNoTracking().Include(x => x.Consultas).FirstOrDefaultAsync(x => x.Id == id);

			if (paciente is null)
				return null;

			return paciente;
		}
	}
}