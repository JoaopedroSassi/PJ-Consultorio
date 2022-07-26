using System.Collections.Generic;
using Consultorio.Models.Entities;

namespace Consultorio.Repository.Interfaces
{
	public interface IPacienteRepository : IBaseRepository
	{
		IEnumerable<Paciente> GetAll();
		Paciente GetById(int id);
	}
}