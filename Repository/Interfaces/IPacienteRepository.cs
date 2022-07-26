using System.Collections.Generic;
using System.Threading.Tasks;
using Consultorio.Models.Dto;
using Consultorio.Models.Entities;

namespace Consultorio.Repository.Interfaces
{
	public interface IPacienteRepository : IBaseRepository
	{
		Task<IEnumerable<PacienteDto>> GetAllPacientesAsync();
		Task<Paciente> GetPacienteByIdAsync(int id);
	}
}