namespace EntityFrameworkModel.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProfesorSustituto")]
    public partial class ProfesorSustituto
    {
        [Key]
        [StringLength(9)]
        public string Sustituido { get; set; }

        public DateTime? FechaFinalizacion { get; set; }

        public virtual Profesor Profesor { get; set; }
    }
}
