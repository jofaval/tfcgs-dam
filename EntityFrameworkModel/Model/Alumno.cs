namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Alumno")]
    public partial class Alumno
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Alumno()
        {
            Certificado = new HashSet<Certificado>();
            Convocatoria = new HashSet<Convocatoria>();
            Proyecto = new HashSet<Proyecto>();
            Reclamacion = new HashSet<Reclamacion>();
        }

        [Key]
        [StringLength(9)]
        public string Persona { get; set; }

        [Required]
        [StringLength(9)]
        public string NumExpediente { get; set; }

        [StringLength(9)]
        public string Tutor { get; set; }

        public DateTime FechaMatriculacion { get; set; }

        [StringLength(10)]
        public string CursoCod { get; set; }

        [StringLength(50)]
        public string CursoNombre { get; set; }

        public virtual Persona Persona1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Certificado> Certificado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Convocatoria> Convocatoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proyecto> Proyecto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reclamacion> Reclamacion { get; set; }
    }
}
