namespace EntityFrameworkModel.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Baja")]
    public partial class Baja
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(9)]
        public string Trabajador { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime FechaInicio { get; set; }

        public DateTime? FechaFinal { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Causa { get; set; }

        public virtual Trabajador Trabajador1 { get; set; }
    }
}
