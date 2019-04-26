namespace EntityFrameworkModel.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ciclo")]
    public partial class Ciclo
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string Cod { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Nombre { get; set; }

        public bool Basica { get; set; }

        public int HorasPractica { get; set; }

        [StringLength(50)]
        public string Rama { get; set; }

        public virtual Curso Curso { get; set; }

        public virtual Superior Superior { get; set; }
    }
}
