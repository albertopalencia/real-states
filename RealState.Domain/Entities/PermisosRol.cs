namespace RealState.Domain.Entities
{
    public partial class PermisosRol
    {
        public int Id { get; set; }
        public int RolId { get; set; }
        public int PermisoId { get; set; }

        public virtual Permisos Permiso { get; set; }
        public virtual Roles Rol { get; set; }
    }
}
