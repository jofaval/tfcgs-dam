namespace EntityFrameworkModel.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bachiller")]
    public partial class Bachiller
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string Cod { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Especializacion { get; set; }

        public virtual Curso Curso { get; set; }
    }
}
