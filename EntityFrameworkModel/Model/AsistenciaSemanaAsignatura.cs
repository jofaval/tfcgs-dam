namespace EntityFrameworkModel.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AsistenciaSemanaAsignatura")]
    public partial class AsistenciaSemanaAsignatura
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

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SemanaNum { get; set; }

        public virtual AsistenciaDiaAsignatura AsistenciaDiaAsignatura { get; set; }

        public virtual Evaluacion Evaluacion { get; set; }
    }
}
