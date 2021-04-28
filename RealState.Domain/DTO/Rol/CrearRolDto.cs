namespace RealState.Domain.DTO.Rol
{
	using RealState.Domain.Entities;

	public class CrearRolDto
	{
		public string Rol { get; set; }
		public bool? Estado { get; set; }


		public static implicit operator Roles(CrearRolDto rol) => new Roles
		{
			Rol = rol.Rol,
			Estado = rol.Estado,
		};
	}
}