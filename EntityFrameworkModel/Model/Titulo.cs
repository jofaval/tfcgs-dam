namespace EntityFrameworkModel.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Titulo")]
    public partial class Titulo
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

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string Firmado { get; set; }

        public virtual Certificado Certificado { get; set; }
    }
}
