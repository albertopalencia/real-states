namespace PruebaTecnica.Infrastructure.Interfaces
{
	using PruebaTecnica.Domain.Entities;
	using PruebaTecnica.Infrastructure.Pages;
	using PruebaTecnica.Interfaces;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public interface IMunicipioRepository : IPagedRepository<Municipio>, IReadRepository<Municipio>, IRemoveRepository<Municipio>,  ICreateRepository<Municipio>, IUpdateRepository<Municipio>
	{
		Task<IEnumerable<Municipio>> Listado();
		Task<PagedList<Municipio>> GetPagedCustomAsync(int pageNumber, int pageSize);
		Task<Municipio> BuscarPorId(int id);
	}
}