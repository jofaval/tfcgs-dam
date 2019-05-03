namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Trabajador")]
    public partial class Trabajador
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trabajador()
        {
            Baja = new HashSet<Baja>();
        }

        [Key]
        [StringLength(9)]
        public string Persona { get; set; }

        public double Sueldo { get; set; }

        public DateTime FechaIncorporacion { get; set; }

        public virtual Administrativo Administrativo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Baja> Baja { get; set; }

        public virtual Especial Especial { get; set; }

        public virtual Mantenimiento Mantenimiento { get; set; }

        public virtual Persona Persona1 { get; set; }

        public virtual Profesor Profesor { get; set; }
    }
}
