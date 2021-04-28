using RealState.Domain.Entities;

namespace RealState.Domain.DTO.Permiso
{
	public class ConsultaPermisoDto
	{
		public int Id { get; set; }
		public string Nombre { get; set; }


		public static implicit operator ConsultaPermisoDto(Permisos permiso) => new ConsultaPermisoDto
		{
			Id = permiso.Id,
			Nombre = permiso.Nombre
		};

		public static implicit operator Permisos(ConsultaPermisoDto permiso) => new Permisos
		{
			Id = permiso.Id,
			Nombre = permiso.Nombre
		};
	}
}