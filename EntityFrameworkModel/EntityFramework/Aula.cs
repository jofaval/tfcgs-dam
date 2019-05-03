namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Aula")]
    public partial class Aula
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Aula()
        {
            Impartimiento = new HashSet<Impartimiento>();
            Departamento = new HashSet<Departamento>();
            Ordenador = new HashSet<Ordenador>();
        }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Impartimiento> Impartimiento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Departamento> Departamento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ordenador> Ordenador { get; set; }
    }
}
