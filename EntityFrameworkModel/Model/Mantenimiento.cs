namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mantenimiento")]
    public partial class Mantenimiento
    {
        [Key]
        [StringLength(9)]
        public string Trabajador { get; set; }

        [Column(TypeName = "text")]
        public string Horario { get; set; }

        [Required]
        [StringLength(100)]
        public string Funcion { get; set; }

        public virtual Trabajador Trabajador1 { get; set; }
    }
}
