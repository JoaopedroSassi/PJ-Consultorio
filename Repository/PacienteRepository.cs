using System.Collections.Generic;
using System.Linq;
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

		public IEnumerable<Paciente> GetAll()
			=> _context.Pacientes.Include(x => x.Consultas).ToList();

		public Paciente GetById(int id)
		{
			Paciente paciente = _context.Pacientes.Include(x => x.Consultas).FirstOrDefault(x => x.Id == id);

			if (paciente is null)
				return null;

			return paciente;
		}
	}
}