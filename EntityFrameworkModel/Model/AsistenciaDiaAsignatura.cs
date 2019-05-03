namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AsistenciaDiaAsignatura")]
    public partial class AsistenciaDiaAsignatura
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(9)]
        public string Persona { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string CursoCod { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string CursoNombre { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(9)]
        public string CodAsignatura { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ConvocatoriaNum { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EvaluacionNum { get; set; }

        public int SemanaNombre { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DiaNombre { get; set; }

        public int? FaltasAsistencia { get; set; }

        public int? FaltasAsistenciaJustificadas { get; set; }

        public virtual AsistenciaSemanaAsignatura AsistenciaSemanaAsignatura { get; set; }
    }
}
