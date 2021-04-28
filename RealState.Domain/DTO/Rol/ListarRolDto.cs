using RealState.Domain.Entities;

namespace RealState.Domain.DTO.Rol
{
	public class ListarRolDto
	{
		public int Id { get; set; }
		public string Rol { get; set; }

		public bool? Estado { get; set; }

		public static implicit operator ListarRolDto(Roles rol) => new ListarRolDto
		{
			Id = rol.Id,
			Estado = rol.Estado,
			Rol = rol.Rol
		};
	}
}