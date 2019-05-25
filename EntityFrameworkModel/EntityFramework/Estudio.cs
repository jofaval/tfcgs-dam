namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Estudio")]
    public partial class Estudio
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
        [StringLength(9)]
        public string Alumno { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Anyo { get; set; }

        public virtual Curso Curso { get; set; }

        public virtual Alumno Alumno1 { get; set; }
    }
}
