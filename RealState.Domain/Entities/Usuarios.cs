namespace RealState.Domain.Entities
{
	public partial class Usuarios : BaseEntity
	{
		public string Usuario { get; set; }
		public string Contrasena { get; set; }
		public string Nombres { get; set; }
		public string Apellidos { get; set; }
		public string Direccion { get; set; }
		public string Telefono { get; set; }
		public string Email { get; set; }
		public int? Edad { get; set; }
		public int RolId { get; set; }

		public virtual Roles IdNavigation { get; set; }
	}
}