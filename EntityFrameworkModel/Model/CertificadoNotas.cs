namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CertificadoNotas
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

        public double NotaMeDia { get; set; }

        public virtual Certificado Certificado { get; set; }
    }
}
