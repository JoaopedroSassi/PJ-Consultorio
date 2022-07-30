using System.Threading.Tasks;
using Consultorio.Context;
using Consultorio.Repository.Interfaces;

namespace Consultorio.Repository
{
	public class BaseRepository : IBaseRepository
	{
		private readonly ConsultorioDbContext _context;

		public BaseRepository(ConsultorioDbContext context)
		{
			_context = context;
		}

		public void Add<T>(T entity) where T : class
		{
			_context.Add(entity);
		}

		public void Delete<T>(T entity) where T : class
		{

		}

		public void Update<T>(T entity) where T : class
		{
			_context.Update(entity);
		}

		public async Task<bool> SaveChangesAsync()
		{
			return await _context.SaveChangesAsync() > 0;
		}
	}
}