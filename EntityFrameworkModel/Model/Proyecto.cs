namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Proyecto")]
    public partial class Proyecto
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(9)]
        public string Alumno { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string SuperiorCod { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string SuperiorNombre { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime FechaInicio { get; set; }

        public DateTime? FechaEntrega { get; set; }

        [StringLength(100)]
        public string Memoria { get; set; }

        [StringLength(100)]
        public string Contenido { get; set; }

        [StringLength(9)]
        public string Tutor { get; set; }

        public double? Nota { get; set; }

        public virtual Alumno Alumno1 { get; set; }

        public virtual Superior Superior { get; set; }
    }
}
