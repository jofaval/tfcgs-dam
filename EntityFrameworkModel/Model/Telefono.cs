namespace EntityFrameworkModel.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Telefono")]
    public partial class Telefono
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(9)]
        public string Persona { get; set; }

        [Key]
        [Column("Telefono", Order = 1)]
        [StringLength(9)]
        public string Telefono1 { get; set; }

        [StringLength(255)]
        public string Comentario { get; set; }

        public virtual Persona Persona1 { get; set; }
    }
}
