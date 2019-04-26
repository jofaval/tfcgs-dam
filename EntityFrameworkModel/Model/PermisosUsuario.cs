namespace EntityFrameworkModel.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PermisosUsuario")]
    public partial class PermisosUsuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PermisosUsuario()
        {
            Usuario = new HashSet<Usuario>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(255)]
        public string Descripcion { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool PermisoAdministrativo { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool PermisoAdmin { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool PermisProfesor { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool PermisoAlumno { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
