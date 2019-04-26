namespace EntityFrameworkModel.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reclamacion")]
    public partial class Reclamacion
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(9)]
        public string Alumno { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NumParte { get; set; }

        [Required]
        [StringLength(50)]
        public string Asunto { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Contenido { get; set; }

        [StringLength(9)]
        public string DirigidoA { get; set; }

        public DateTime? FechaEnvio { get; set; }

        public DateTime? FechaRevision { get; set; }

        [Column(TypeName = "text")]
        public string Respuesta { get; set; }

        [StringLength(9)]
        public string Revisor { get; set; }

        public bool? EnTramite { get; set; }

        public virtual Alumno Alumno1 { get; set; }
    }
}
