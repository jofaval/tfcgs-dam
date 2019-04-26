namespace EntityFrameworkModel.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Persona")]
    public partial class Persona
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Persona()
        {
            Telefono = new HashSet<Telefono>();
            Usuario = new HashSet<Usuario>();
        }

        [Key]
        [StringLength(9)]
        public string Dni { get; set; }

        [Required]
        [StringLength(9)]
        public string Nif { get; set; }

        [Required]
        [StringLength(100)]
        public string Calle { get; set; }

        [Required]
        [StringLength(6)]
        public string CodigoPostal { get; set; }

        [Required]
        [StringLength(4)]
        public string Patio { get; set; }

        [Required]
        [StringLength(3)]
        public string Piso { get; set; }

        [Required]
        [StringLength(4)]
        public string Puerta { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellidos { get; set; }

        public DateTime FechaNacimiento { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public virtual Alumno Alumno { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Telefono> Telefono { get; set; }

        public virtual Trabajador Trabajador { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
