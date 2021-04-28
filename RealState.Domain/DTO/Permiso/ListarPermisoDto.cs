using RealState.Domain.Entities;

namespace RealState.Domain.DTO.Permiso
{
	public class ListarPermisoDto
	{
		public int Id { get; set; }
		public string Nombre { get; set; }

		public static implicit operator ListarPermisoDto(Permisos permiso) => new ListarPermisoDto
		{
			Id = permiso.Id,
			Nombre = permiso.Nombre
		};
	}
}