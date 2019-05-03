namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Certificado")]
    public partial class Certificado
    {
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
        public DateTime FechaSolicitud { get; set; }

        public DateTime? FechaDisponible { get; set; }

        public DateTime? FechaRecogido { get; set; }

        public bool? Pagado { get; set; }

        public bool? EnTramite { get; set; }

        public double? Importe { get; set; }

        public virtual Alumno Alumno1 { get; set; }

        public virtual Curso Curso { get; set; }

        public virtual CertificadoMatricula CertificadoMatricula { get; set; }

        public virtual CertificadoNotas CertificadoNotas { get; set; }

        public virtual CertificadoTitulo CertificadoTitulo { get; set; }

        public virtual Titulo Titulo { get; set; }
    }
}
