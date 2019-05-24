namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Impartimiento")]
    public partial class Impartimiento
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(9)]
        public string Profesor { get; set; }

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
        [Column(Order = 4, TypeName = "date")]
        public DateTime HoraInicio { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Dia { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Anyo { get; set; }

        [Key]
        [Column(Order = 7, TypeName = "date")]
        public DateTime HoraFinal { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(2)]
        public string AulaNum { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(2)]
        public string AulaPiso { get; set; }

        public virtual Aula Aula { get; set; }

        public virtual Horario Horario { get; set; }

        public virtual Profesor Profesor1 { get; set; }
    }
}
