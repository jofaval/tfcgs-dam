namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Departamento")]
    public partial class Departamento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Departamento()
        {
            Administrativo = new HashSet<Administrativo>();
            Profesor = new HashSet<Profesor>();
        }

        [Key]
        [StringLength(10)]
        public string Cod { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Nombre { get; set; }

        [StringLength(2)]
        public string Num { get; set; }

        [StringLength(2)]
        public string Piso { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Administrativo> Administrativo { get; set; }

        public virtual Aula Aula { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Profesor> Profesor { get; set; }
    }
}
