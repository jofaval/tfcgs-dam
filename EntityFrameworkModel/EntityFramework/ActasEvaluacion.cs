namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ActasEvaluacion")]
    public partial class ActasEvaluacion
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string CursoCod { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string CursoNombre { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime Fecha { get; set; }

        [Column(TypeName = "text")]
        public string Temas { get; set; }

        [Column(TypeName = "text")]
        public string Contenido { get; set; }

        [StringLength(9)]
        public string Profesor { get; set; }

        public virtual Curso Curso { get; set; }

        public virtual Profesor Profesor1 { get; set; }
    }
}
