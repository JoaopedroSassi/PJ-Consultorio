using System.Collections.Generic;
using System.Threading.Tasks;
using Consultorio.Models.Dto;
using Consultorio.Models.Entities;

namespace Consultorio.Repository.Interfaces
{
	public interface IProfissionalRepository : IBaseRepository
	{
		Task<IEnumerable<ProfissionalDto>> GetAllProfissionaisAsync();
		Task<Profissional> GetProfissionalByIdAsync(int id);
	}
}
