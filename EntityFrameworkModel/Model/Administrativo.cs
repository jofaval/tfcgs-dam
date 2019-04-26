namespace EntityFrameworkModel.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Administrativo")]
    public partial class Administrativo
    {
        [Key]
        [StringLength(9)]
        public string Trabajador { get; set; }

        [StringLength(10)]
        public string Departamento { get; set; }

        [StringLength(100)]
        public string Funcion { get; set; }

        public virtual Departamento Departamento1 { get; set; }

        public virtual Trabajador Trabajador1 { get; set; }
    }
}
