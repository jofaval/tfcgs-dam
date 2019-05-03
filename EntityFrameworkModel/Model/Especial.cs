namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Especial")]
    public partial class Especial
    {
        [Key]
        [StringLength(9)]
        public string Trabajador { get; set; }

        [Required]
        [StringLength(100)]
        public string Funcion { get; set; }

        public virtual Trabajador Trabajador1 { get; set; }
    }
}
