namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ordenador")]
    public partial class Ordenador
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string Num { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string Piso { get; set; }

        [Column(TypeName = "text")]
        public string Estado { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(5)]
        public string CodOrdenadorAula { get; set; }

        [StringLength(40)]
        public string Ip { get; set; }

        [StringLength(50)]
        public string SistemaOperativo { get; set; }

        public virtual Aula Aula { get; set; }
    }
}
