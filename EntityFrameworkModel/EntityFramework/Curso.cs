namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Curso")]
    public partial class Curso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Curso()
        {
            Certificado = new HashSet<Certificado>();
            Convocatoria = new HashSet<Convocatoria>();
            Horario = new HashSet<Horario>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string Cod { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(9)]
        public string Tutor { get; set; }

        public DateTime? FechaMatriculacion { get; set; }

        public bool? TurnoTarde { get; set; }

        public virtual Bachiller Bachiller { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Certificado> Certificado { get; set; }

        public virtual Ciclo Ciclo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Convocatoria> Convocatoria { get; set; }

        public virtual Eso Eso { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Horario> Horario { get; set; }
    }
}
