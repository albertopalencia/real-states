namespace RealState.Domain.DTO.Permiso
{
	using RealState.Domain.Entities;

	public class CrearPermisoDto
	{
		public string Nombre { get; set; }

		public static implicit operator Permisos(CrearPermisoDto permiso) => new Permisos
		{
			Nombre = permiso.Nombre
		};
	}
}