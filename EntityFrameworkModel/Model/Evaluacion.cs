namespace EntityFrameworkModel.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Evaluacion")]
    public partial class Evaluacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Evaluacion()
        {
            AsistenciaSemanaAsignatura = new HashSet<AsistenciaSemanaAsignatura>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(9)]
        public string Alumno { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string CursoCod { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string CursoNombre { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(9)]
        public string CodAsignatura { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ConvocatoriaNum { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EvaluacionNum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AsistenciaSemanaAsignatura> AsistenciaSemanaAsignatura { get; set; }

        public virtual Convocatoria Convocatoria { get; set; }

        public virtual Nota Nota { get; set; }
    }
}
