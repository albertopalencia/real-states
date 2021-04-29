
namespace PruebaTecnica.Infrastructure.Repositories
{
	using Microsoft.EntityFrameworkCore;
	using PruebaTecnica.Domain.Entities;
	using PruebaTecnica.Infrastructure.DataAccessEntityFrameWork;
	using PruebaTecnica.Infrastructure.Interfaces;
	using PruebaTecnica.Infrastructure.Pages;
	using PruebaTecnica.Repositories;
	using System.Collections.Generic;
	using System.Diagnostics.CodeAnalysis;
	using System.Linq;
	using System.Threading.Tasks;

	[ExcludeFromCodeCoverage]
	public class MunicipioRepository : GenericRepository<Municipio>, IMunicipioRepository
	{
		public MunicipioRepository(PruebaTecnicaContext context) : base(context)
		{
		}

		public async Task<Municipio> BuscarPorId(int id)
		{
			return await _entities.Include(m => m.Departamento).FirstOrDefaultAsync(s => s.Id == id);
		}

		public async Task<PagedList<Municipio>> GetPagedCustomAsync(int pageNumber, int pageSize)
		{
			var query = _entities.Include(m => m.Departamento).AsQueryable();
			query = query.OrderByDescending(or => or.Id);
			var items = await query.Take(pageSize).ToListAsync();
			var totalCount = await query.CountAsync();
			var result = PagedList<Municipio>.Create(items, totalCount, pageNumber, pageSize);
			return result;
		}


		public async Task<IEnumerable<Municipio>> Listado()
		{
			return await _entities.Include(m => m.Departamento).ToListAsync();
		}
	}
}