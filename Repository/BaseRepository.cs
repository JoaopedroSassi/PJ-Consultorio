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

		}

		public void Delete<T>(T entity) where T : class
		{

		}

		public void Update<T>(T entity) where T : class
		{

		}

		public bool SaveChanges()
		{
			return true;
		}
	}
}