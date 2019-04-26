namespace EntityFrameworkModel.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(9)]
        public string Persona { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(16)]
        public string Username { get; set; }

        [Required]
        [StringLength(32)]
        public string Contrasenya { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool PermisoAdministrativo { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool PermisoAdmin { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool PermisProfesor { get; set; }

        [Key]
        [Column(Order = 6)]
        public bool PermisoAlumno { get; set; }

        public virtual PermisosUsuario PermisosUsuario { get; set; }

        public virtual Persona Persona1 { get; set; }
    }
}
