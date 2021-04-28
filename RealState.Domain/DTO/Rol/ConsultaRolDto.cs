namespace RealState.Domain.DTO.Rol
{
	using RealState.Domain.Entities;

	public class ConsultaRolDto
	{
		public int Id { get; set; }
		public string Rol { get; set; }

		public bool? Estado { get; set; }

		public static implicit operator ConsultaRolDto(Roles rol) => new ConsultaRolDto
		{
			Id = rol.Id,
			Estado = rol.Estado,
			Rol = rol.Rol
		};

		public static implicit operator Roles(ConsultaRolDto rol) => new Roles
		{
			Id = rol.Id,
			Estado = rol.Estado,
			Rol = rol.Rol
		};
	}
}