namespace EntityFrameworkModel.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Profesor")]
    public partial class Profesor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Profesor()
        {
            Impartimiento = new HashSet<Impartimiento>();
        }

        [Key]
        [StringLength(9)]
        public string Trabajador { get; set; }

        public DateTime FechaIncorporacion { get; set; }

        [Required]
        [StringLength(10)]
        public string Departamento { get; set; }

        public virtual Departamento Departamento1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Impartimiento> Impartimiento { get; set; }

        public virtual Trabajador Trabajador1 { get; set; }

        public virtual ProfesorSustituto ProfesorSustituto { get; set; }
    }
}
